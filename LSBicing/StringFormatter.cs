namespace LSBicing
{
    class StringFormatter
    {
        string stringWithBlanks;

        public StringFormatter(string str){
            SetString(str);
        }

        // getter
        public string GetString(){
            return this.stringWithBlanks;
        }

        //setter
        public void SetString(string str){
            this.stringWithBlanks = str;
        }

        //method
        public void ReplaceBlanks(){
            SetString(this.stringWithBlanks.Replace(" ", "+"));
        }

    }
}
