using System.Collections.Generic;
using System.Threading.Tasks;
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

[Pool(typeof(TokenCardPool))]
public class Scrap() : CustomCardModel(0, CardType.Skill, CardRarity.Token, TargetType.None)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new CardsVar(1)];

    public bool hasPlayed = false;

    protected override HashSet<CardTag> CanonicalTags
    {
        get => new HashSet<CardTag>() { TheTinkerEnums.Scrap };
    }


    public override IEnumerable<CardKeyword> CanonicalKeywords => [CardKeyword.Exhaust];

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        Scrap scrap = this;
        scrap.hasPlayed = true;
        IEnumerable<CardModel> cardModels =
            await CardPileCmd.Draw(choiceContext, scrap.DynamicVars.Cards.BaseValue, scrap.Owner);

    }


    public override async Task AfterCardExhausted(PlayerChoiceContext choiceContext, CardModel card, bool causedByEthereal)
    {
        CardModel scrap = this;
        if (scrap.IsUpgraded == false)
            return;
        if (this != card || this.hasPlayed == true)
            return;
        //Not sure if I actually need this right here or not. This could be another one of those weired interactions with multiple players.
        if (scrap.Owner != this.Owner)
            return;
        await CardPileCmd.Draw(choiceContext, scrap.DynamicVars.Cards.BaseValue, scrap.Owner);
        
        
    }




}