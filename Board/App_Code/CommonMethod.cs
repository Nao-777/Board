using Board.App_Code;
using System;

namespace application
{
    public class CommonMethod
    {
        /// <summary>英数字のアルファベット（定数）</summary>
        private const string WORDS = Constants.ALPHA_NUMERAL;
        /// <summary>
        /// 文字の整合性(characterIntegrity)を確認
        /// </summary>
        /// <param name="targetWord">整合性を確認したい文字列</param>
        /// <param name="lowerLimit">下限値の設定</param>
        /// <param name="upperLimit">上限値の設定</param>
        /// <param name="checkedAlphabet">整合したい文字列がアルファベット化確認する。</param>
        /// <returns>bool型。入力文字が空でないかつ引数で指定した条件（lowerLimit<=targetWord<=upperLimit）を満たしている場合true。入力文字が英数字の場合は、入力文字列すべてが英数字か判定する条件が追加される</returns>
        public bool CheckCharacterIntegrity(string targetWord, int lowerLimit, int upperLimit, bool checkedAlphabet)
        {
            if (string.IsNullOrEmpty(targetWord)
                    || (targetWord.Length > upperLimit)
                        || (targetWord.Length < lowerLimit)) return false;
            if (checkedAlphabet
                    && !CheckAlphabetNum(targetWord)) return false;
            return true;
        }

        /// <summary>
        /// 英数字の判定するメソッド
        /// </summary>
        /// <param name="targetWord">入力文字列</param>
        /// <returns>bool型。引数targetWordの文字すべてが半角英数字の場合trueを返す</returns>
        private bool CheckAlphabetNum(string targetWord)
        {
            for (int i = 0; i < targetWord.Length; i++)
            {
                var judge = false;
                var target = targetWord[i];
                for (int j = 0; j < WORDS.Length; j++)
                {
                    if (WORDS[j].Equals(target))
                    {
                        judge = true;
                        break;
                    }
                }
                if (judge == false) return false;
            }
            return true;
        }

        /// <summary>
        /// 指定した文字数でランダムな文字列を作成
        /// </summary>
        /// <param name="numberOfDigits">作成するIDの桁数を指定</param>
        /// <param name="tableName">作成するIDを格納するテーブル名</param>
        /// <returns>引数numberOfDigitsで指定した桁で半角英数字のランダムな文字列
        /// 引数のテーブル名が存在しない場合はnullを返す
        /// </returns>
        public string CreateRandomId(int numberOfDigits, string tableName)
        {
            var createdId = new char[numberOfDigits];
            var random = new Random();
            for (int i = 0; i < createdId.Length; i++)
            {
                ///Random.Next()引数に指定した数値を最大値として乱数を取得できる
                createdId[i] = WORDS[random.Next(WORDS.Length)];
            }
            var result = new string(createdId);
            // 重複していないか確認
            switch (tableName)
            {
                case Constants.TABLE_USER:
                    if (!string.IsNullOrEmpty(new UserTable().GetByField(result, Constants.FIELD_USER_USER_ID))) return CreateRandomId(numberOfDigits, tableName);
                    break;
                case Constants.TABLE_BOARD:
                    if (!string.IsNullOrEmpty(new BoardTable().GetByField(result, Constants.FIELD_BOARD_ARTICL_ID))) return CreateRandomId(numberOfDigits, tableName);
                    break;
                case Constants.TABLE_INARTICL:
                    if (!string.IsNullOrEmpty(new ResTable().GetByField(result, Constants.FIELD_IN_ARTICL_MESSAGE_ID))) return CreateRandomId(numberOfDigits, tableName);
                    break;
                default:
                    return string.Empty;
            }
            return result;
        }
    }
}