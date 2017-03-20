using Gravitrips.Core.GameFields;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Gravitips.Core.Tests
{
    [TestClass]
    public class ClassicGameFieldTests
    {
        private ClassicGameField _gameField;

        [TestInitialize]
        public void Inititalize()
        {
            _gameField = new ClassicGameField();
            _gameField.Initialize();
        }

        [TestMethod]
        public void VerticalLineCompleteGame()
        {
            for (var i = _gameField.RowsCount - 1; i >= 0; i--)
            {
                _gameField.Field[1, i] = 1;
            }

            var finished = _gameField.CheckGameFinished();
            Assert.IsTrue(finished);
        }

        [TestMethod]
        public void HorizontalLineCompleteGame()
        {
            for (var i = 0; i < _gameField.ColumnsCount; i++)
            {
                _gameField.Field[i, _gameField.RowsCount - 1] = 1;
            }

            var finished = _gameField.CheckGameFinished();
            Assert.IsTrue(finished);
        }

        [TestMethod]
        public void DiagonalLine1CompleteGame()
        {
            for (var i = 0; i < 4; i++)
            {
                _gameField.Field[i, _gameField.RowsCount - i - 1] = 1;
            }
            _gameField.Field[1, 5] = 2;
            _gameField.Field[2, 5] = 2;
            _gameField.Field[3, 5] = 2;
            _gameField.Field[2, 4] = 2;
            _gameField.Field[3, 4] = 2;
            _gameField.Field[3, 3] = 2;

            var finished = _gameField.CheckGameFinished();
            Assert.IsTrue(finished);
        }

        [TestMethod]
        public void DiagonalLine2CompleteGame()
        {            
            for (var i = 0; i < 4; i++)
            {
                _gameField.Field[i, 2 + i] = 1;
            }
            _gameField.Field[0, 5] = 2;
            _gameField.Field[0, 4] = 2;
            _gameField.Field[0, 3] = 2;
            _gameField.Field[1, 4] = 2;
            _gameField.Field[1, 5] = 2;
            _gameField.Field[2, 5] = 2;

            var finished = _gameField.CheckGameFinished();
            Assert.IsTrue(finished);
        }
    }
}
