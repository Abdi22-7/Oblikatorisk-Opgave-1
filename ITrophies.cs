namespace Oblikatorisk_Opgave_1
{
    public interface ITrophies
    {
        public void Add(Trophy trophy);
        
        public bool Remove(int id);
        public Trophy? Update(int id, Trophy values);
        public List<Trophy> Get();
        public List<Trophy> Get(int year);
        public Trophy? GetById(int id);
        
        
    }
}
