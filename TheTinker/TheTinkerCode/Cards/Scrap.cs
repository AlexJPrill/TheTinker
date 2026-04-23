using BaseLib.Abstracts;
using BaseLib.Cards.Variables;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.CardPools;
using TheTinker.TheTinkerCode.Character;

namespace TheTinker.TheTinkerCode.Cards;

[Pool(typeof(TheTinkerCardPool))]
public class Scrap() : CustomCardModel(0, CardType.Skill, CardRarity.Token, TargetType.None)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new CardsVar(1)];


    public override IEnumerable<CardKeyword> CanonicalKeywords => [CardKeyword.Exhaust];

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        Scrap scrap = this;
        IEnumerable<CardModel> cardModels =
            await CardPileCmd.Draw(choiceContext, scrap.DynamicVars.Cards.BaseValue, scrap.Owner);

    }

}