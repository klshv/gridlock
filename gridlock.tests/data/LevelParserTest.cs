using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gridlock.application;
using gridlock.data;
using Xunit;

namespace gridlock.tests.data
{
    public class LevelParserTest
    {
        [Fact]
        public void When_JsonWithOnlyDimensions_Parse_Should_ReturnFieldWithoutBlocks()
        {
            var width = 6; 
            var height = 7;
            var levelJson = $$"""
                {
                    "width": {{width}},
                    "height": {{height}}
                }
                """;
            var parser = new LevelParser();

            // Act
            var actualField = parser.Parse(levelJson);

            // Assert 
            Assert.Equal(width, actualField.Width);
            Assert.Equal(height, actualField.Height);
            Assert.Null(actualField.Target);
            Assert.Empty(actualField.Blocks);
        }

        [Fact]
        public void When_JsonWithTarget_Parse_Should_ReturnFieldWithTarget()
        {
            var x = 1;
            var y = 2;
            var direction = application.Direction.Horizontal;
            var length = 3;

            var levelJson = $$"""
                {
                    "target": {
                        "x": {{x}},
                        "y": {{y}},
                        "direction": "{{direction.ToString().ToLower()}}",
                        "length": {{length}}
                    }
                }
                """;
            var parser = new LevelParser();

            // Act
            var actualField = parser.Parse(levelJson);

            // Assert 
            Assert.Equal(x, actualField.Target.X);
            Assert.Equal(y, actualField.Target.Y);
            Assert.Equal(application.Direction.Horizontal, actualField.Target.Direction);
            Assert.Equal(length, actualField.Target.Length);
        }

        [Fact]
        public void When_JsonWithBlocks_Parse_Should_ReturnFieldWithBlocks()
        {
            Block expectedBlock1 = new(2, Direction.Vertical, 0, 1);
            Block expectedBlock2 = new(3, Direction.Horizontal, 2, 0);

            var levelJson = $$"""
                {
                    "blocks": [
                        {
                            "x": {{expectedBlock1.X}},
                            "y": {{expectedBlock1.Y}},
                            "direction": "{{expectedBlock1.Direction.ToString().ToLower()}}",
                            "length": {{expectedBlock1.Length}}
                        },
                        {
                            "x": {{expectedBlock2.X}},
                            "y": {{expectedBlock2.Y}},
                            "direction": "{{expectedBlock2.Direction.ToString().ToLower()}}",
                            "length": {{expectedBlock2.Length}}
                        }
                    ]
                }
                """;
            var parser = new LevelParser();

            // Act
            var actualField = parser.Parse(levelJson);

            // Assert 
            Assert.Collection(
                actualField.Blocks,
                block => Assert.Equal(expectedBlock1, block),
                block => Assert.Equal(expectedBlock2, block)
                );
        }


    }
}
