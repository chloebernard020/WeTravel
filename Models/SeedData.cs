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

                Continent AmeriqueSud = new Continent
                {
                    Nom = "Amérique du Sud"
                };
                context.Continents.AddRange(
                Europe,
                AmeriqueSud
                );

                Pays Belgique = new Pays
                {
                    Nom = "Belgique",
                    Continent = Europe
                };

                Pays France = new Pays
                {
                    Nom = "France",
                    Continent = Europe
                };

                Pays Espagne = new Pays
                {
                    Nom = "Espagne",
                    Continent = Europe
                };

                Pays Chili = new Pays
                {
                    Nom = "Chili",
                    Continent = AmeriqueSud
                };

                Pays Perou = new Pays
                {
                    Nom = "Pérou",
                    Continent = AmeriqueSud
                };
                context.Pays.AddRange(
                Belgique,
                France,
                Espagne,
                Chili,
                Perou
                );

                Ville Liege = new Ville
                {
                    Nom = "Liège",
                    Pays = Belgique
                };
                Ville Paris = new Ville
                {
                    Nom = "Paris",
                    Pays = France
                };
                Ville Madrid = new Ville
                {
                    Nom = "Madrid",
                    Pays = Espagne
                };
                Ville Lima = new Ville
                {
                    Nom = "Lima",
                    Pays = Perou
                };

                Ville Santiago = new Ville
                {
                    Nom = "Santiago",
                    Pays = Chili
                };
                context.Villes.AddRange(
                Liege,
                Paris,
                Madrid,
                Lima,
                Santiago
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
                Lieu Bueren = new Lieu
                {
                    Nom = "L'escalier de la montagne de Bueren",
                    Description = "La montagne de Bueren est un escalier de 374 marches (avec une pente de 30 %) reliant le quartier Féronstrée et Hors-Château au Péri et à la citadelle traversant les Coteaux dans la ville de Liège en Belgique.",
                    Ville = Liege
                };
                Lieu TourEiffel = new Lieu
                {
                    Nom = "La Tour Eiffel",
                    Description = "La tour Eiffel est une tour de fer puddlé de 330 m2 de hauteur (avec antennes) située à Paris, à l’extrémité nord-ouest du parc du Champ-de-Mars en bordure de la Seine dans le 7e arrondissement. Son adresse officielle est 5, avenue Anatole-France.",
                    Ville = Paris
                };
                Lieu ArcDeTriomphe = new Lieu
                {
                    Nom = "L'Arc de Triomphe'",
                    Description = "Souhaité par Napoléon Ier dès 1806, l'Arc de triomphe est inauguré en 1836 par le roi des Français, Louis-Philippe, qui le dédie aux armées de la Révolution et de l'Empire. Le Soldat inconnu est inhumé sur le terre-plein en 1921.",
                    Ville = Paris
                };

                Lieu PlazaDeArmas = new Lieu
                {
                    Nom = "La Plaza de Armas",
                    Description = "La Plaza de Armas est une place publique de la ville de Santiago, capitale du Chili.",
                    Ville = Santiago
                };

                Lieu PalacioDeLaMoneda = new Lieu
                {
                    Nom = "Le Palacio de la Moneda",
                    Description = "Le Palacio de la Moneda, à Santiago, est le siège de la présidence du Chili et l'un des bâtiments les plus remarquables jamais construits par les Espagnols dans leurs colonies en Amérique latine.",
                    Ville = Santiago
                };
                Lieu BasiliqueSFA = new Lieu
                {
                    Nom = "Basilique et monastère Saint-François-d'Assise",
                    Description = "La basilique et le monastère Saint-François-d'Assise de Lima est un édifice catholique situé au nord-est de la Plaza Mayor, dans la ville de Lima, la capitale du Pérou. Avec le centre historique de Lima, il est inscrit sur la liste du Patrimoine mondial de l'UNESCO depuis 1991.",
                    Ville = Lima
                };
                Lieu ParqueDelAmor = new Lieu
                {
                    Nom = "Le Parque del Amor",
                    Description = "Tout au bout du quartier de Miraflores, en haut de la falaise qui fait face à la mer, le parc de l’amour est une jolie promenade longée par un mur en céramique coloré.",
                    Ville = Lima
                };

                context.Lieux.AddRange(
                Laboverie,
                Unegaufrettesaperlipopette,
                Bueren,
                TourEiffel,
                ArcDeTriomphe,
                PlazaDeArmas,
                PalacioDeLaMoneda,
                BasiliqueSFA,
                ParqueDelAmor
                );
            }
            context.SaveChanges();
        }

    }

}