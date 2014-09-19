namespace Company.RandomDataGenerator.Generators
{
    internal abstract class DataGenerator : IDataGenerator
    {
        protected CompanyDbContext db;
        protected RNG rng;
        protected int count;

        public DataGenerator(CompanyDbContext db)
        {
            this.rng = RNG.GetInstance();
            this.db = db;
        }

        public virtual void Generate(int numberOfObjects)
        {
            this.count = numberOfObjects;
        }
    }
}
