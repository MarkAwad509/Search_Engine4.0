using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CorpusBuilder.BLL.Model
{
    public class Document
    {
        public int Id { get; set; }
        public IList<String> Terms { get; set; }
        public string Text { get; set; }
        public int Length { get; set; }

        //Relation
        public int AUTO_GEN_ID = 1;
        public Document(string text)
        {
            this.Id = AUTO_GEN_ID;
            this.Text = text;
            this.Terms = splitText(text);
            this.Length = Terms.Count;
            AUTO_GEN_ID++;
        }

        public IList<string> splitText(string text)
        {
            //Enleve les symboles du texte pour n'avoir que le term
            text = Regex.Replace(text, "[,\\.\\?\\!;:«»\\(\\)\\-]+", "");
            text = Regex.Replace(text, "[\\\r\\\n]+", " ");
            return text.ToLower().Split(' ');
        }

        public int findOccurences(string term)
        {
            int count = 0;

            foreach(string word in this.Terms)
            {
                if (word.Equals(term))
                {
                    count++;
                }
            }return count;
        }

        public bool contains(string term)
        {
            if (this.Terms.Contains(term)){
                return true;
            }
            else { return false; }
        }

        public IList<int> findPositions(string term)
        {
            
            IList<int> listint = new List<int>();
            for (int i = 0; i < this.Terms.Count(); i++)
            {
                if (this.Terms[i].Equals(term))
                {
                    listint.Add(i + 1);
                }
            }
            // foreach (string word in this.Terms)
            // {
            //     if (word.Equals(term))
            //     {
            //         listint.Add(this.Terms.IndexOf(word));
                    
            //     }
            // }
            return listint;
        }

        public override string ToString()
        {
            return $"(Document ID: {this.Id}, Length: {this.Length}, Text:\n \"{this.Text}\")";
        }
    }
}