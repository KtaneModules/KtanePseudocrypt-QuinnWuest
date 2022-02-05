using System;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using Rnd = UnityEngine.Random;

public class PseudocryptScript : MonoBehaviour
{
    public KMBombModule Module;
    public KMBombInfo BombInfo;
    public KMAudio Audio;

    public TextMesh ButtonText;
    public TextMesh ScreenText;
    public KMSelectable[] ArrowBtns;
    public KMSelectable SubmitBtn;

    private int _moduleId;
    private static int _moduleIdCounter = 1;
    private bool _moduleSolved;

    private static readonly string[] _textEntires = new string[] { "A HALFMOON GLOWED ON SMOOTH GRANITE BOULDERS TURNING THEM SILVER", "THE SILENCE WAS BROKEN ONLY BY THE RIPPLE OF WATER FROM THE SWIFT BLACK RIVER AND THE WHISPER OF TREES IN THE FOREST BEYOND", "THERE WAS A STIRRING IN THE SHADOWS AND FROM ALL AROUND LITHE DARK SHAPES CREPT STEALTHILY OVER THE ROCKS", "UNSHEATHED CLAWS GLINTED IN THE MOONLIGHT", "WARY EYES FLASHED LIKE AMBER", "AND THEN AS IF ON A SILENT SIGNAL THE CREATURES LEAPED AT EACH OTHER AND SUDDENLY THE ROCKS WERE ALIVE WITH WRESTLING SCREECHING CATS", "AT THE CENTER OF THE FRENZY OF FUR AND CLAWS A MASSIVE DARK TABBY PINNED A BRACKENCOLORED TOM TO THE GROUND AND DREW UP HIS HEAD TRIUMPHANTLY", "OAKHEART THE TABBY GROWLED", "HOW DARE YOU HUNT IN OUR TERRITORY THE SUNNINGROCKS BELONG TO THUNDERCLAN", "AFTER TONIGHT TIGERCLAW THIS WILL BE JUST ANOTHER RIVERCLAN HUNTING GROUND THE BRACKENCOLORED TOM SPAT BACK", "A WARNING YOWL CAME FROM THE SHORE SHRILL AND ANXIOUS", "LOOK OUT MORE RIVERCLAN WARRIORS ARE COMING", "TIGERCLAW TURNED TO SEE SLEEK WET BODIES SLIDING OUT OF THE WATER BELOW THE ROCKS", "THE DRENCHED RIVERCLAN WARRIORS BOUNDED SILENTLY UP THE SHORE AND HURLED THEMSELVES INTO BATTLE WITHOUT EVEN STOPPING TO SHAKE THE WATER FROM THEIR FUR", "THE DARK TABBY GLARED DOWN AT OAKHEART", "YOU MAY SWIM LIKE OTTERS BUT YOU AND YOUR WARRIORS DO NOT BELONG IN THIS FOREST", "HE DREW BACK HIS LIPS AND SHOWED HIS TEETH AS THE CAT STRUGGLED BENEATH HIM", "THE DESPERATE SCREAM OF A THUNDERCLAN SHECAT ROSE ABOVE THE CLAMOR", "A WIRY RIVERCLAN TOM HAD PINNED THE BROWN WARRIOR FLAT ON HER BELLY", "NOW HE LUNGED TOWARD HER NECK WITH JAWS STILL DRIPPING FROM HIS SWIM ACROSS THE RIVER", "TIGERCLAW HEARD THE CRY AND LET GO OF OAKHEART", "WITH A MIGHTY LEAP HE KNOCKED THE ENEMY WARRIOR AWAY FROM THE SHECAT", "QUICK MOUSEFUR RUN HE ORDERED BEFORE TURNING ON THE RIVERCLAN TOM WHO HAD THREATENED HER", "MOUSEFUR SCRAMBLED TO HER PAWS WINCING FROM A DEEP GASH ON HER SHOULDER AND RACED AWAY", "BEHIND HER TIGERCLAW SPAT WITH RAGE AS THE RIVERCLAN TOM SLICED OPEN HIS NOSE", "BLOOD BLINDED HIM FOR AN INSTANT BUT HE LUNGED FORWARD REGARDLESS AND SANK HIS TEETH INTO THE HIND LEG OF HIS ENEMY", "THE RIVERCLAN CAT SQUEALED AND STRUGGLED FREE", "TIGERCLAW", "THE YOWL CAME FROM A WARRIOR WITH A TAIL AS RED AS FOX FUR", "THIS IS USELESS THERE ARE TOO MANY RIVERCLAN WARRIORS", "NO REDTAIL", "THUNDERCLAN WILL NEVER BE BEATEN TIGERCLAW YOWLED BACK LEAPING TO REDTAILS SIDE", "THIS IS OUR TERRITORY", "BLOOD WAS WELLING AROUND HIS BROAD BLACK MUZZLE AND HE SHOOK HIS HEAD IMPATIENTLY SCATTERING SCARLET DROPS ONTO THE ROCKS", "THUNDERCLAN WILL HONOR YOUR COURAGE TIGERCLAW BUT WE CANNOT AFFORD TO LOSE ANY MORE OF OUR WARRIORS REDTAIL URGED", "BLUESTAR WOULD NEVER EXPECT HER WARRIORS TO FIGHT AGAINST THESE IMPOSSIBLE ODDS", "WE WILL HAVE ANOTHER CHANCE TO AVENGE THIS DEFEAT", "HE MET TIGERCLAWS AMBEREYED GAZE STEADILY THEN REARED AWAY AND SPRANG ONTO A BOULDER AT THE EDGE OF THE TREES", "RETREAT THUNDERCLAN", "RETREAT HE YOWLED", "AT ONCE HIS WARRIORS SQUIRMED AND STRUGGLED AWAY FROM THEIR OPPONENTS", "SPITTING AND SNARLING THEY BACKED TOWARD REDTAIL", "FOR A HEARTBEAT THE RIVERCLAN CATS LOOKED CONFUSED", "WAS THIS BATTLE SO EASILY WON THEN OAKHEART YOWLED A JUBILANT CRY", "AS SOON AS THEY HEARD HIM THE RIVERCLAN WARRIORS RAISED THEIR VOICES AND JOINED THEIR DEPUTY IN CATERWAULING THEIR VICTORY", "REDTAIL LOOKED DOWN AT HIS WARRIORS", "WITH A FLICK OF HIS TAIL HE GAVE THE SIGNAL AND THE THUNDERCLAN CATS DIVED DOWN THE FAR SIDE OF THE SUNNINGROCKS THEN DISAPPEARED INTO THE TREES", "TIGERCLAW FOLLOWED LAST", "HE HESITATED AT THE EDGE OF THE FOREST AND GLANCED BACK AT THE BLOODSTAINED BATTLEFIELD", "HIS FACE WAS GRIM HIS EYES FURIOUS SLITS", "THEN HE LEAPED AFTER HIS CLAN INTO THE SILENT FOREST", "IN A DESERTED CLEARING AN OLD GRAY SHECAT SAT ALONE STARING UP AT THE CLEAR NIGHT SKY", "ALL AROUND HER IN THE SHADOWS SHE COULD HEAR THE BREATHING AND STIRRINGS OF SLEEPING CATS", "A SMALL TORTOISESHELL SHECAT EMERGED FROM A DARK CORNER HER PAWSTEPS QUICK AND SOUNDLESS", "THE GRAY CAT DIPPED HER HEAD IN GREETING", "HOW IS MOUSEFUR SHE MEOWED", "HER WOUNDS ARE DEEP BLUESTAR ANSWERED THE TORTOISESHELL SETTLING HERSELF ON THE NIGHTCOOL GRASS", "BUT SHE IS YOUNG AND STRONG SHE WILL HEAL QUICKLY", "AND THE OTHERS", "THEY WILL ALL RECOVER TOO", "BLUESTAR SIGHED", "WE ARE LUCKY NOT TO HAVE LOST ANY OF OUR WARRIORS THIS TIME", "YOU ARE A GIFTED MEDICINE CAT SPOTTEDLEAF", "SHE TILTED HER HEAD AGAIN AND STUDIED THE STARS", "I AM DEEPLY TROUBLED BY TONIGHTS DEFEAT", "THUNDERCLAN HAS NOT BEEN BEATEN IN ITS OWN TERRITORY SINCE I BECAME LEADER SHE MURMURED", "THESE ARE DIFFICULT TIMES FOR OUR CLAN", "THE SEASON OF NEWLEAF IS LATE AND THERE HAVE BEEN FEWER KITS", "THUNDERCLAN NEEDS MORE WARRIORS IF IT IS TO SURVIVE", "BUT THE YEAR IS ONLY JUST BEGINNING SPOTTEDLEAF POINTED OUT CALMLY", "THERE WILL BE MORE KITS WHEN GREENLEAF COMES", "THE GRAY CAT TWITCHED HER BROAD SHOULDERS", "PERHAPS", "BUT TRAINING OUR YOUNG TO BECOME WARRIORS TAKES TIME", "IF THUNDERCLAN IS TO DEFEND ITS TERRITORY IT MUST HAVE NEW WARRIORS AS SOON AS POSSIBLE", "ARE YOU ASKING STARCLAN FOR ANSWERS MEOWED SPOTTEDLEAF GENTLY FOLLOWING BLUESTARS GAZE AND STARING UP AT THE SWATH OF STARS GLITTERING IN THE DARK SKY", "IT IS AT TIMES LIKE THIS WE NEED THE WORDS OF ANCIENT WARRIORS TO HELP US", "HAS STARCLAN SPOKEN TO YOU BLUESTAR ASKED", "NOT FOR SOME MOONS BLUESTAR", "SUDDENLY A SHOOTING STAR BLAZED OVER THE TREETOPS", "SPOTTEDLEAFS TAIL TWITCHED AND THE FUR ALONG HER SPINE BRISTLED", "BLUESTARS EARS PRICKED BUT SHE REMAINED SILENT AS SPOTTEDLEAF CONTINUED TO GAZE UPWARD", "AFTER A FEW MOMENTS SPOTTEDLEAF LOWERED HER HEAD AND TURNED TO BLUESTAR", "IT WAS A MESSAGE FROM STARCLAN SHE MURMURED", "A DISTANT LOOK CAME INTO HER EYES", "FIRE ALONE CAN SAVE OUR CLAN", "FIRE BLUESTAR ECHOED", "BUT FIRE IS FEARED BY ALL THE CLANS HOW CAN IT SAVE US", "SPOTTEDLEAF SHOOK HER HEAD", "I DO NOT KNOW SHE ADMITTED", "BUT THIS IS THE MESSAGE STARCLAN HAS CHOSEN TO SHARE WITH ME", "THE THUNDERCLAN LEADER FIXED HER CLEAR BLUE EYES ON THE MEDICINE CAT", "YOU HAVE NEVER BEEN WRONG BEFORE SPOTTEDLEAF SHE MEOWED", "IF STARCLAN HAS SPOKEN THEN IT MUST BE SO", "FIRE WILL SAVE OUR CLAN" };
    private int _chosenEntryIx;
    private string _chosenEntryText;
    private int[] _textShuffle = new int[26];
    private string _shuffledAlphabet;
    private string _displayText;
    private int _correctLetter;
    private int _currentLetter;
    private bool _isAnimating;
    private Coroutine _strike;

    private void Start()
    {
        _moduleId = _moduleIdCounter++;
        SubmitBtn.OnInteract += SubmitPress;
        for (int i = 0; i < ArrowBtns.Length; i++)
            ArrowBtns[i].OnInteract += ArrowPress(i);

        _currentLetter = Rnd.Range(0, 26);
        ButtonText.text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"[_currentLetter].ToString();
        _chosenEntryIx = Rnd.Range(0, _textEntires.Length);
        _chosenEntryText = _textEntires[_chosenEntryIx];
        _textShuffle = Enumerable.Range(0, 26).ToArray();
        shuffleAgain:
        int count = 0;
        _shuffledAlphabet = "";
        _textShuffle.Shuffle();
        for (int i = 0; i < _textShuffle.Length; i++)
        {
            _shuffledAlphabet += "ABCDEFGHIJKLMNOPQRSTUVWXYZ"[_textShuffle[i]].ToString();
            if (_textShuffle[i] == i)
            {
                _correctLetter = i;
                count++;
            }
        }
        if (count != 1 || !_chosenEntryText.ToCharArray().Contains("ABCDEFGHIJKLMNOPQRSTUVWXYZ"[_correctLetter]))
            goto shuffleAgain;
        Debug.LogFormat("[Pseudocrypt #{0}] The chosen text is \"{1}\".", _moduleId, _chosenEntryText);
        Debug.LogFormat("[Pseudocrypt #{0}] The shuffled alphabet is {1}.", _moduleId, _shuffledAlphabet);
        _displayText = "";
        for (int i = 0; i < _chosenEntryText.Length; i++)
        {
            if (_chosenEntryText[i].ToString() == " ")
                _displayText += " ";
            else
                _displayText += "ABCDEFGHIJKLMNOPQRSTUVWXYZ"[Array.IndexOf(_shuffledAlphabet.ToCharArray(), _chosenEntryText[i])];
        }
        Debug.LogFormat("[Pseudocrypt #{0}] The text on the screen is \"{1}\".", _moduleId, _displayText);
        Debug.LogFormat("[Pseudocrypt #{0}] The letter to submit is {1}.", _moduleId, "ABCDEFGHIJKLMNOPQRSTUVWXYZ"[_correctLetter]);
        ScreenText.text = _displayText.WordWrap(25).Join("\n");
    }

    private KMSelectable.OnInteractHandler ArrowPress(int btn)
    {
        return delegate ()
        {
            ArrowBtns[btn].AddInteractionPunch(0.5f);
            Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, ArrowBtns[btn].transform);
            if (_moduleSolved)
                return false;
            if (btn == 0)
                _currentLetter = (_currentLetter + 25) % 26;
            else
                _currentLetter = (_currentLetter + 1) % 26;
            ButtonText.text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"[_currentLetter].ToString();
            return false;
        };
    }

    private bool SubmitPress()
    {
        SubmitBtn.AddInteractionPunch(0.5f);
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, SubmitBtn.transform);
        if (_moduleSolved)
            return false;
        if (_currentLetter == _correctLetter)
        {
            _moduleSolved = true;
            Module.HandlePass();
            Audio.PlaySoundAtTransform("Solve", transform);
            ScreenText.text = _chosenEntryText.WordWrap(25).Join("\n");
            ScreenText.color = new Color(0, 1, 0);
            Debug.LogFormat("[Pseudocrypt #{0}] Correctly submitted {1}. Module solved.", _moduleId, "ABCDEFGHIJKLMNOPQRSTUVWXYZ"[_correctLetter]);
        }
        else
        {
            if (_strike != null)
                StopCoroutine(_strike);
            _strike = StartCoroutine(Strike());
            Module.HandleStrike();
            Debug.LogFormat("[Pseudocrypt #{0}] Incorrectly submitted {1}. Strike.", _moduleId, "ABCDEFGHIJKLMNOPQRSTUVWXYZ"[_currentLetter]);
        }
        return false;
    }

    private IEnumerator Strike()
    {
        ScreenText.color = new Color(1, 0, 0);
        yield return new WaitForSeconds(2f);
        if (!_moduleSolved)
            ScreenText.color = new Color(1, 1, 1);
    }

#pragma warning disable 0414
    private readonly string TwitchHelpMessage = "!{0} <letter> [Submit the letter as your answer.]";
#pragma warning restore 0414

    private IEnumerator ProcessTwitchCommand(string command)
    {
        var m = Regex.Match(command, @"^\s*([A-Z])\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
        if (!m.Success)
            yield break;
        yield return null;
        var target = m.Groups[1].Value.ToUpperInvariant()[0] - 'A';
        while (_currentLetter != target)
        {
            var distance = (Math.Abs(_currentLetter - target) + 13) % 26 - 13;
            if (_currentLetter > target)
                distance *= -1;
            if (distance > 0)
                yield return new[] { ArrowBtns[1] };
            else if (distance < 0)
                yield return new[] { ArrowBtns[0] };
        }
        SubmitBtn.OnInteract();
    }

    private IEnumerator TwitchHandleForcedSolve()
    {
        var target = _correctLetter;
        while (_currentLetter != target)
        {
            var distance = (Math.Abs(_currentLetter - target) + 13) % 26 - 13;
            if (_currentLetter > target)
                distance *= -1;
            if (distance > 0)
                ArrowBtns[1].OnInteract();
            else if (distance < 0)
                ArrowBtns[0].OnInteract();
            yield return new WaitForSeconds(0.1f);
        }
        SubmitBtn.OnInteract();
    }
}
