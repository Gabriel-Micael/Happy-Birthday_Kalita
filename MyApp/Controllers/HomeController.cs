using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyApp.Models;

namespace MyApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var friends = new List<FriendModel>
            {
                //faltando
                new FriendModel { Id = 1, Name = "Pai", Description = "Deus te abençoe e dê muitos anos de vida e saúde 👏👏👏👏\r\n",
                //faltando
                ImagePath = "img/pai.jpg" },
                new FriendModel { Id = 1, Name = "Mãe", Description = "\"Parabéns pelo seu aniversário. Que Deus te dê muitos anos de vida. Que Deus possa te abençoar muito, dando " +
                "muita alegria, paz e saúde. Que você possa conquistar o que almeja, se Deus assim quiser!\"",
                ImagePath = "img/mae.jpg" },
                new FriendModel { Id = 1, Name = "Gabriel", Description = "\"Sei que não sou o melhor irmão e muitas vezes sou bem egoísta" +
                ", mas você sempre foi uma inspiração para me tornar melhor. Tanto profissionalmente como espiritualmente. Então saiba que, para mim, você é muito importante. Te AMO!\" ",
                    ImagePath = "img/Gabriel.png" },
                new FriendModel { Id = 2, Name = "Efraim", Description = "\"Hoje é um dia muito especial, pois celebramos os 30 anos da minha querida irmã.\r\nQue alegria poder ver" +
                " o quanto você cresceu, amadureceu e se tornou essa mulher incrível, forte e inspiradora.\r\nCada conquista sua é motivo de orgulho para todos que conhecem sua " +
                "trajetória .\r\nQue essa nova fase venha repleta de bênçãos, amor, saúde e muitas realizações.\r\nVocê merece tudo de melhor que a vida pode oferecer.\r\nQue nunca" +
                " faltem motivos para sorrir e pessoas verdadeiras ao seu lado.\r\nContinue brilhando com sua alegria contagiante e sua determinação.\r\nTrinta anos é apenas o " +
                "começo de uma jornada ainda mais bonita e cheia de sucesso.\r\nParabéns, minha irmã! Que Deus te abençoe imensamente hoje e sempre.\r\nTe amo muito e estarei " +
                "sempre torcendo por você!\"",
                    ImagePath = "img/efraim.jpg" },
                new FriendModel { Id = 2, Name = "Josy", Description = "Parabéns pelo seu dia.\r\nMuita saúde, novas conquistas e muitas realizações.\r\nQue vc continue sendo essa pessoa" +
                " incrível de coração enorme sempre disposta a ajudar o proximo.\r\nTe desejo tudo de bom e muito sucesso hoje e sempre.\r\nObrigada por todo apoio e carinho em especial " +
                "nessa nova fase com o Pedro.\r\nQue Deus na sua infinita misericórdia de cubra de bênçãos.\r\nFeliz aniversário \U0001f973",
                    ImagePath = "img/josy.jpg" },
                new FriendModel { Id = 4, Name = "Luis", Description = "\"Feliz aniversário Kalita. Hoje é um dia importante para uma pessoa importante. Você fez parte da minha vida, " +
                "sendo carinhosa e me ajudando nos eixos emocionais, intelectuais e espirituais. Parabéns!\"",
                    ImagePath = " img/luis.jpg" },
                //faltando
                new FriendModel { Id = 4, Name = "Abel", Description = "\"Parabéns maninha! Nesse dia tão especial quero te parabenizar pelo dia e dizer que você é uma pessoa muito " +
                "importante na nossa família e também quero te desejar muita saúde, paz, alegria,amor e bençãos dos céus sobre sua vida! Saiba que você é uma irmã show e te amamos!\"",
                    ImagePath = "img/abel.jpg" },
                new FriendModel { Id = 4, Name = "Logan", Description = "AuAuuuuAU! (Parabéns)",
                    ImagePath = "img/logan.jpg" },
                new FriendModel { Id = 6, Name = "Igor", Description = "\"Eu não sei falar muita coisa, mas meus parabenzão à você, tudo de bom!\"\r\nObs: dito de cima de um" +
                " andaime.",
                    ImagePath = "img/igor.jpg" },
                new FriendModel { Id = 7, Name = "Gabriela", Description = "\"Dos primeiros passos da minha caminhada Cristã até os momentos mais importantes da minha vida,você " +
                "esteve e está presente!!\r\nSou extremamente grata pela sua vida!!\r\nNos momentos de lágrimas,em que muitas vezes eu perdia o chão,você foi meu apoio e ombro " +
                "amigo e a minha oração,de todo o coração é que Deus continue te abençoando e te sustentando poderosamente.\r\nA correria da vida e talvez as circunstâncias hoje" +
                " talvez nos faça estar mais distantes,mas o carinho e consideração uma pela outra jamais mudará!!\r\nFeliz aniversário e tudo de melhor debaixo da graça e da " +
                "vontade de Deus\r\nAmo você!! Abraços,Gabi 💗\r\"\n",
                    ImagePath = "img/gabi.jpg" },
                new FriendModel { Id = 8, Name = "Telma", Description = "\"Parabéns kalita!\r\nQuero lhe desejar grandes bênçãos na sua vida e que Deus venha iluminar você cada" +
                " dia mais e mais. Mesmo no curto espaço de tempo em que nos conhecemos  já comprovou ser merecedora da minha confiança e sei que posso contar com você .\r\nEspero" +
                " que nossa amizade floresça.\"",
                    ImagePath = "img/telma.jpg" },
                new FriendModel { Id = 3, Name = "Joel", Description = "\"Parabéns Kalita. Que a alegria de hoje se multiplique por todos os dias deste novo ano. " +
                "Que seu dia seja recheado de carinho e abraços que aquecem a alma. Feliz aniversário 🎂\r\n\"",
                    ImagePath = "img/joel.jpg" },
                new FriendModel { Id = 3, Name = "Claudilene e Gilmar", Description = "\"Hoje é um dia de gratidão a Deus por mais um ano da sua vida. É impossível não olhar pra trás e lembrar de quantas fases vivemos juntas — as risadas, as conversas " +
                "intermináveis, os sonhos que nasciam no meio de tanta inocência… e ver que, mesmo com o tempo e as mudanças da vida, o carinho e a amizade permanecem firmes.\r\n\r\n" +
                "Você é uma daquelas pessoas raras, que deixa marcas boas por onde passa. Que o Senhor continue abençoando os teus caminhos, te sustentando em cada passo e enchendo " +
                "tua vida de paz, alegria e amor.\r\n\r\nObrigada por nos permitir fazer parte da sua história de vida.\r\nTe amamos!!\"",
                    ImagePath = "img/claudilene.jpg" },
                new FriendModel { Id = 3, Name = "Osana", Description = "\"Feliz aniversário, 🎉\r\nminha Amiga!⚘ \r\nQue seu dia seja tão incrível quanto a nossa amizade, Que a " +
                "presença do Senhor seja todos os dias na sua vida.\r\n Você é um presente de Deus ,parceira de risadas e confidente; sempre dividindo os melhores momentos.\r\n " +
                "Agradeço ao Senhor por sua existência. 🙏🏻\r\n❤Amo você❤ Osana\"",
                    ImagePath = "img/osana.jpg" },
                new FriendModel { Id = 3, Name = "Kemily", Description = "\"Trintouu🎉 Parabéns nessa data tão importante que Deus venha trazer a realização dos seus sonhos, te" +
                " guardando e cuidando sempre da irmãzinha que Deus me deu❤\"",
                    ImagePath = "img/kemily.jpg" },
                new FriendModel { Id = 3, Name = "Delsergio", Description = "\"Feliz  aniversário,minha amiga irmã! que o amor de Deus continue  fluir através da sua vida e que " +
                "você continue sendo essa benção para todos os que estão ao seu redor. Obrigado por ser essa pessoa tão especial. \r\nEu e minha família te amamos!\"",
                    ImagePath = "img/delsergio.jpg" },
                new FriendModel { Id = 3, Name = "Luana e Fabiano", Description = "\"Kalita, não temos como agradecer com palavras por ter sua amizade!\r\n\r\nEstamos imensamente" +
                " felizes por mais um ano de sua vida, saiba que você é benção em nossas vidas e que sua amizade é importante e valiosa!\r\n\r\nQue este novo ano de sua vida te " +
                "traga muitas alegrias, muita paz e muito amor! Desejamos toda felicidade a você!\"",
                    ImagePath = "img/luana_fabiano.jpg" },
                new FriendModel { Id = 3, Name = "Isac", Description = "Feliz aniversário Tia Kalita! Te amo 💙",
                    ImagePath = "img/isac.jpg" },
                new FriendModel { Id = 3, Name = "Késia", Description = "Parabéns!  Desejo a você uma fase cheia de coisas boas, saúde e muitas alegrias. Que este novo tempo traga " +
                "ainda mais conquistas e momentos felizes! ✨",
                    ImagePath = "img/kesia.jpg" },
                new FriendModel { Id = 3, Name = "Juninho", Description = "Parabéns Kalita \r\nDesejo tudo de bom pra você. Você é uma moça especial, é inteligente, elegante e " +
                "simpática. E o mais importante, é uma mulher temente à Deus , sempre muito dedicada na obra de Deus, fazendo tudo com muito amor . Saiba que te admiro muito e desejo" +
                " muitas bênçãos na sua vida. \r\nUm grande abraço do JUNINHO",
                    ImagePath = "img/juninho.jpg" },
                new FriendModel { Id = 3, Name = "Priscila e Everaldo", Description = "Parabéns Kalita!Que Deus te abençoe ricamente não só neste dia especial,mas todos os dias da" +
                " sua vida!\r\n\r\nSomos gratos a Deus pela sua vida ,por seu amor e  dedicação na obra de Deus,desejamos saúde, alegria e que este novo ano seja repleto de bênçãos" +
                " e de frutos para a glória de Deus. Que sua vida seja sempre guiada por Jesus e você continue sendo luz para todos nós. \r\nFelicidades!\r\nCom carinho, Everaldo e" +
                " Priscila",
                    ImagePath = "img/pri.jpg" },
                new FriendModel { Id = 2, Name = "Nathanael", Description = "Passando para te desejar um feliz aniversário!\r\nQue o seu dia seja tão especial quanto você uma pessoa " +
                "que se destaca pela dedicação, pelo\r\namor no que faz e pelo jeito incrível de ser.\r\nVocê é alguém admirável, cheia de qualidades que iluminam quem está ao seu " +
                "redor.\r\nDesejo que todos os seus sonhos se realizem e que Deus continue abençoando a sua vida com\r\nsaúde, alegria e muitas conquistas.\r\nContinue sendo essa " +
                "pessoa maravilhosa que faz a diferença por onde passa.\r\nParabéns e muitas felicidades!",
                    ImagePath = "img/tael.jpg" },
                new FriendModel { Id = 3, Name = "Rodrigo's family", Description = "Feliz aniversário Kalita, te desejo muita saúde, paz, alegrias, que Deus continue te abençoando " +
                "sempre, que você consiga conquistar tudo que sonha, tudo de bom na sua vida hoje e sempre\U0001f973🙏🏼\r\n",
                    ImagePath = "img/rodrigo.jpg" },

            };

            return View(friends);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
