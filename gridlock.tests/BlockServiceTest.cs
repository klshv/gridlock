using System;
using gridlock.application;
using Xunit;

namespace gridlock.tests
{
    public class BlockServiceTest
    {
        [Fact]
        public void GetBlockMovedLeft_Should_ReturnMovedBlock()
        {
            var blockLength = 2;
            var blockDirection = Direction.Horizontal;
            var position = (2, 1);

            // Arrange
            var inputBlock = new Block(blockLength, blockDirection, position.Item1, position.Item2);
            var blockService = new BlockService();
            var expectedBlock = new Block(blockLength, blockDirection, position.Item1 - 1, position.Item2);

            // Act
            var actualBlock = blockService.GetBlockMovedLeft(inputBlock);

            // Assert
            /* Assert.Equal(expectedBlock, actualBlock) */
            /* Assert.True(expectedBlock.Equals(actualBlock)) */
            Assert.Equal(expectedBlock.X, actualBlock.X);
            Assert.Equal(expectedBlock.Y, actualBlock.Y);
            Assert.Equal(expectedBlock.Direction, actualBlock.Direction);
            Assert.Equal(expectedBlock.Length, actualBlock.Length);
        }

        [Fact]
        public void GetBlockMovedRight_Should_ReturnMovedBlock()
        {
            var blockLength = 2;
            var blockDirection = Direction.Horizontal;
            var position = (2, 1);

            // Arrange
            var inputBlock = new Block(blockLength, blockDirection, position.Item1, position.Item2);
            var blockService = new BlockService();
            var expectedBlock = new Block(blockLength, blockDirection, position.Item1 + 1, position.Item2);

            // Act
            var actualBlock = blockService.GetBlockMovedRight(inputBlock);

            // Assert
            /* Assert.Equal(expectedBlock, actualBlock) */
            /* Assert.True(expectedBlock.Equals(actualBlock)) */

            Assert.Equal(expectedBlock.X, actualBlock.X);
            Assert.Equal(expectedBlock.Y, actualBlock.Y);
            Assert.Equal(expectedBlock.Direction, actualBlock.Direction);
            Assert.Equal(expectedBlock.Length, actualBlock.Length);
        }

        [Fact]
        public void GetBlockMovedUp_Should_ReturnMovedBlock()
        {
            var blockLength = 2;
            var blockDirection = Direction.Vertical;
            var position = (2, 1);

            // Arrange
            var inputBlock = new Block(blockLength, blockDirection, position.Item1, position.Item2);
            var blockService = new BlockService();
            var expectedBlock = new Block(blockLength, blockDirection, position.Item1, position.Item2 + 1);

            // Act
            var actualBlock = blockService.GetBlockMovedUp(inputBlock);

            // Assert
            /* Assert.Equal(expectedBlock, actualBlock) */
            /* Assert.True(expectedBlock.Equals(actualBlock)) */
            Assert.Equal(expectedBlock.X, actualBlock.X);
            Assert.Equal(expectedBlock.Y, actualBlock.Y);
            Assert.Equal(expectedBlock.Direction, actualBlock.Direction);
            Assert.Equal(expectedBlock.Length, actualBlock.Length);
        }

        [Fact]
        public void GetBlockMovedDown_Should_ReturnMovedBlock()
        {
            var blockLength = 2;
            var blockDirection = Direction.Vertical;
            var position = (2, 1);

            // Arrange
            var inputBlock = new Block(blockLength, blockDirection, position.Item1, position.Item2);
            var blockService = new BlockService();
            var expectedBlock = new Block(blockLength, blockDirection, position.Item1, position.Item2 - 1);

            // Act
            var actualBlock = blockService.GetBlockMovedDown(inputBlock);

            // Assert
            /* Assert.Equal(expectedBlock, actualBlock) */
            /* Assert.True(expectedBlock.Equals(actualBlock)) */
            Assert.Equal(expectedBlock.X, actualBlock.X);
            Assert.Equal(expectedBlock.Y, actualBlock.Y);
            Assert.Equal(expectedBlock.Direction, actualBlock.Direction);
            Assert.Equal(expectedBlock.Length, actualBlock.Length);
        }
    }
}
