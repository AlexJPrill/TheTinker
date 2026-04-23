using BaseLib.Abstracts;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.CardSelection;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using TheTinker.TheTinkerCode.Cards;
using TheTinker.TheTinkerCode.Character;

namespace TheTinker.TheTinkerCode.Relics;

[Pool(typeof(TheTinkerRelicPool))]
public class Scrapper() : CustomRelicModel
{
    public override RelicRarity Rarity => RelicRarity.Starter;
    
    public override async Task AfterPlayerTurnStart(PlayerChoiceContext choiceContext, Player player)
    {
        Scrapper source = this;
        if (player != source.Owner)
            return;
        CardSelectorPrefs prefs = new CardSelectorPrefs(CardSelectorPrefs.TransformSelectionPrompt, 0, 1);
        CardModel original = (await CardSelectCmd.FromHand(choiceContext, source.Owner, prefs, (Func<CardModel, bool>) null, (AbstractModel) source)).FirstOrDefault<CardModel>();
        if (original == null)
            return;
        CardPileAddResult? nullable = await CardCmd.TransformTo<Scrap>(original);


    }
}