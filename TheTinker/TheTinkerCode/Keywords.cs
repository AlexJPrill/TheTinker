using BaseLib.Patches.Content;
using MegaCrit.Sts2.Core.Entities.Cards;

namespace TheTinker.TheTinkerCode;

  
public static class Keywords
{
   [CustomEnum("Worn")] [KeywordProperties(AutoKeywordPosition.After)]
   public static CardKeyword Worn;
}