using CorpusBuilder.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CorpusBuilder.DAL
{
    public class InMemoryDocumentDAO : IDocumentDAO
    {
        public IList<Document> Documents { get; set; }

        public InMemoryDocumentDAO()
        {
            this.Documents = new List<Document>();
        }

        private void loadCorpus()
        {
            Document text1 = new Document("Que ton nom soit sanctifié ; que ton règne vienne ; que ta volonté soit faite sur la terre comme au ciel. Donne-nous aujourd'hui notre pain quotidien ; pardonne-nous nos offenses, comme nous aussi nous pardonnons à ceux qui nous ont offensés ; ne nous induis pas en tentation, mais délivre-nous du malin. ! »");
            this.Documents.Add(text1);

            Document text2 = new Document("Je vous salue Marie, pleine de grâces, le Seigneur est avec vous, Vous êtes bénie entre toutes les femmes, et Jésus, le fruit de vos entrailles est béni, Sainte Marie, Mère de Dieu, priez pour nous, pauvres pécheurs, maintenant et à l'heure de notre mort. Amen.");
            this.Documents.Add(text2);

            Document text3 = new Document("Je crois en Dieu, le Père tout-puissant, créateur du ciel et de la terre. Et en Jésus Christ, son Fils unique, notre Seigneur, qui a été conçu du Saint - Esprit, est né de la  Vierge Marie, a souffert sous Ponce Pilate, a été crucifié, est mort et a été enseveli, est descendu aux enfers, le troisième jour est ressuscité des morts, est monté aux cieux, est assis à la droite de Dieu le Père tout - puissant, d’où il viendra juger les vivants et les morts. Je crois en l’Esprit Saint, à la sainte Église catholique, à la communion des saints, à la rémission des péchés, à la résurrection de la chair, à la vie éternelle. Amen.");
            this.Documents.Add(text3);
        }
        public IList<Document> fetchAllDocuments()
        {
            loadCorpus();
            return this.Documents;
        }
    }
}
