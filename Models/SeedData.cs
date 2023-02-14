public class SeedData
{
    public static void Initiate()
    {
        using (var context = new WeTravelContext())
        {
            if (context.Lieux.Any())
            {
                return;   // DB already filled
            }

            else
            {
                Continent Europe = new Continent
                {
                    Nom = "Europe"
                };
                context.Continents.AddRange(
                Europe
                );

                Pays Belgique = new Pays
                {
                    Nom = "Belgique",
                    Continent = Europe
                };
                context.Pays.AddRange(
                Belgique
                );
                Ville Liege = new Ville
                {
                    Nom = "Liège",
                    Pays = Belgique
                };
                context.Villes.AddRange(
                Liege
                );

                // Add Lieu
                Lieu Laboverie = new Lieu
                {
                    Nom = "La Boverie",
                    Description = "La Boverie est un musée liégeois qui a ouvert ses portes en mai 2016. Le musée est installé dans l'ancien Palais des beaux-arts de Liège de l'Exposition universelle de 1905 situé dans le parc de la Boverie.",
                    Ville = Liege
                };
                Lieu Unegaufrettesaperlipopette = new Lieu
                {
                    Nom = "Une Gaufrette Saperlipopette",
                    Description = "Une Gaufrette Saperlipopette vous propose pains, gaufres, produits gourmands, et crèmes glacées, le tout sans additifs et à base d'ingrédients locaux.",
                    Ville = Liege
                };
                context.Lieux.AddRange(
                Laboverie,
                Unegaufrettesaperlipopette
                );
            }
            context.SaveChanges();
        }

    }

}