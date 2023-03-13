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
                    Nom = "L'Europe"
                };
                context.Continents.AddRange(
                Europe
                );

                Continent AmeriqueNord = new Continent
                {
                    Nom = "L'Amérique du Nord"
                };
                context.Continents.AddRange(
                AmeriqueNord
                );

                Continent Asie = new Continent
                {
                    Nom = "L'Asie"
                };
                context.Continents.AddRange(
                Asie
                );

                Continent Afrique = new Continent
                {
                    Nom = "L'Afrique"
                };
                context.Continents.AddRange(
                Afrique
                );

                Continent Oceanie = new Continent
                {
                    Nom = "L'Océanie"
                };
                context.Continents.AddRange(
                Oceanie
                );

                Continent AmeriqueSud = new Continent
                {
                    Nom = "L'Amérique du Sud"
                };
                context.Continents.AddRange(
                Europe,
                AmeriqueSud
                );

                Continent Antarctique = new Continent
                {
                    Nom = "L'Antarctique"
                };
                context.Continents.AddRange(
                Antarctique
                );

                Pays Belgique = new Pays
                {
                    Nom = "La Belgique",
                    Continent = Europe
                };

                Pays Portugal = new Pays
                {
                    Nom = "Le Portugal",
                    Continent = Europe
                };

                Pays Suede = new Pays
                {
                    Nom = "La Suède",
                    Continent = Europe
                };

                Pays France = new Pays
                {
                    Nom = "La France",
                    Continent = Europe
                };

                Pays Espagne = new Pays
                {
                    Nom = "L'Espagne",
                    Continent = Europe
                };

                Pays Chili = new Pays
                {
                    Nom = "Le Chili",
                    Continent = AmeriqueSud
                };

                Pays Perou = new Pays
                {
                    Nom = "Le Pérou",
                    Continent = AmeriqueSud
                };

                Pays Coreedusud = new Pays
                {
                    Nom = "La Corée du Sud",
                    Continent = Asie
                };
                Pays Japon = new Pays
                {
                    Nom = "Le Japon",
                    Continent = Asie
                };
                Pays Vietnam = new Pays
                {
                    Nom = "Le Vietnam",
                    Continent = Asie
                };

                Pays Australie = new Pays
                {
                    Nom = "L'Australie",
                    Continent = Asie
                };

                Pays Inde = new Pays
                {
                    Nom = "L'Inde",
                    Continent = Asie
                };

                Pays Laos = new Pays
                {
                    Nom = "Le Laos",
                    Continent = Asie
                };

                Pays EtatsUnis = new Pays
                {
                    Nom = "Les Etats-Unis",
                    Continent = AmeriqueNord
                };

                Pays Canada = new Pays
                {
                    Nom = "Le Canada",
                    Continent = AmeriqueNord
                };

                context.Pays.AddRange(
                Belgique,
                France,
                Espagne,
                Chili,
                Perou,
                Portugal,
                Suede,
                Coreedusud,
                Japon,
                Vietnam,
                Australie,
                Inde,
                Laos,
                EtatsUnis,
                Canada
                );

                Ville Liege = new Ville
                {
                    Nom = "Liège",
                    Pays = Belgique
                };
                Ville Bruxelles = new Ville
                {
                    Nom = "Bruxelles",
                    Pays = Belgique
                };
                Ville Paris = new Ville
                {
                    Nom = "Paris",
                    Pays = France
                };

                Ville Perpignan = new Ville
                {
                    Nom = "Perpignan",
                    Pays = France
                };
                Ville Bordeaux = new Ville
                {
                    Nom = "Bordeaux",
                    Pays = France
                };

                Ville Barcelone = new Ville
                {
                    Nom = "Barcelone",
                    Pays = Espagne
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

                Ville Cuzco = new Ville
                {
                    Nom = "Cuzco",
                    Pays = Perou
                };
                Ville Arequipa = new Ville
                {
                    Nom = "Arequipa",
                    Pays = Perou
                };

                Ville Santiago = new Ville
                {
                    Nom = "Santiago",
                    Pays = Chili
                };
                Ville Valparaiso = new Ville
                {
                    Nom = "Valparaíso",
                    Pays = Chili
                };
                Ville Iquique = new Ville
                {
                    Nom = "Iquique",
                    Pays = Chili
                };

                Ville Stockholm = new Ville
                {
                    Nom = "Stockholm",
                    Pays = Suede
                };
                Ville Malmo = new Ville
                {
                    Nom = "Malmö",
                    Pays = Suede
                };
                Ville Goteborg = new Ville
                {
                    Nom = "Göteborg",
                    Pays = Suede
                };

                Ville Lisbonne = new Ville
                {
                    Nom = "Lisbonne",
                    Pays = Portugal
                };

                Ville Porto = new Ville
                {
                    Nom = "Porto",
                    Pays = Portugal
                };

                Ville Coimbra = new Ville
                {
                    Nom = "Coimbra",
                    Pays = Portugal
                };

                Ville Seoul = new Ville
                {
                    Nom = "Séoul",
                    Pays = Coreedusud
                };

                Ville Busan = new Ville
                {
                    Nom = "Busan",
                    Pays = Coreedusud
                };

                Ville Jeju = new Ville
                {
                    Nom = "Jeju",
                    Pays = Coreedusud
                };

                Ville Tokyo = new Ville
                {
                    Nom = "Tokyo",
                    Pays = Japon
                };

                Ville Kyoto = new Ville
                {
                    Nom = "Kyoto",
                    Pays = Japon
                };
                Ville Osaka = new Ville
                {
                    Nom = "Osaka",
                    Pays = Japon
                };
                Ville Hanoi = new Ville
                {
                    Nom = "Hanoï",
                    Pays = Vietnam
                };

                Ville Hoian = new Ville
                {
                    Nom = "Hoi An",
                    Pays = Vietnam
                };

                Ville HoChiMin = new Ville
                {
                    Nom = "Hô Chi Minh-Ville",
                    Pays = Vietnam
                };

                Ville Sydney = new Ville
                {
                    Nom = "Sydney",
                    Pays = Australie
                };

                Ville Melbourne = new Ville
                {
                    Nom = "Melbourne",
                    Pays = Australie
                };

                Ville Perth = new Ville
                {
                    Nom = "Perth",
                    Pays = Australie
                };

                Ville NewYork = new Ville
                {
                    Nom = "New York",
                    Pays = EtatsUnis

                };

                Ville Toronto = new Ville
                {
                    Nom = "Toronto",
                    Pays = Canada

                };

                context.Villes.AddRange(
                Liege,
                Paris,
                Madrid,
                Lima,
                Santiago,
                Perpignan,
                Bordeaux,
                Barcelone,
                Cuzco,
                Arequipa,
                Valparaiso,
                Iquique,
                Stockholm,
                Malmo,
                Goteborg,
                Bruxelles,
                Lisbonne,
                Porto,
                Coimbra,
                Seoul,
                Busan,
                Jeju,
                Tokyo,
                Kyoto,
                Osaka,
                Hanoi,
                Hoian,
                HoChiMin,
                Sydney,
                Melbourne,
                Perth,
                NewYork,
                Toronto
                );

                // Add Lieu
                Lieu Laboverie = new Lieu
                {
                    Nom = "La Boverie",
                    Description = "La Boverie est un musée liégeois qui a ouvert ses portes en mai 2016. Le musée est installé dans l'ancien Palais des beaux-arts de Liège de l'Exposition universelle de 1905 situé dans le parc de la Boverie.",
                    Ville = Liege,
                    Photo = "https://lesmuseesdeliege.be/wp-content/uploads/2020/02/boverie-600300.jpg"
                };
                Lieu Unegaufrettesaperlipopette = new Lieu
                {
                    Nom = "Une Gaufrette Saperlipopette",
                    Description = "Une Gaufrette Saperlipopette vous propose pains, gaufres, produits gourmands, et crèmes glacées, le tout sans additifs et à base d'ingrédients locaux.",
                    Ville = Liege,
                    Photo = "https://images.squarespace-cdn.com/content/v1/5795d7c2b8a79baa23ced763/bab0cb30-7e43-4c79-b6d0-3260d51bce86/SEB_3879.jpg"
                };
                Lieu Bueren = new Lieu
                {
                    Nom = "L'escalier de la montagne de Bueren",
                    Description = "La montagne de Bueren est un escalier de 374 marches (avec une pente de 30 %) reliant le quartier Féronstrée et Hors-Château au Péri et à la citadelle traversant les Coteaux dans la ville de Liège en Belgique.",
                    Ville = Liege,
                    Photo = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/89/L%C3%BCttich_Montagne.jpg/800px-L%C3%BCttich_Montagne.jpg"
                };
                Lieu GrandPlace = new Lieu
                {
                    Nom = "Grand-Place",
                    Description = "La Grand-Place est la place centrale de la Ville de Bruxelles. Mondialement renommée pour sa richesse ornementale et esthétique, elle est bordée par les maisons des corporations, l'Hôtel de Ville et la Maison du Roi.",
                    Ville = Bruxelles,
                    Photo = "data:image/jpeg;base64,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"
                };
                Lieu TourEiffel = new Lieu
                {
                    Nom = "La Tour Eiffel",
                    Description = "La tour Eiffel est une tour de fer puddlé de 330 m2 de hauteur (avec antennes) située à Paris, à l’extrémité nord-ouest du parc du Champ-de-Mars en bordure de la Seine dans le 7e arrondissement. Son adresse officielle est 5, avenue Anatole-France.",
                    Ville = Paris,
                    Photo = "https://www.parisinfo.com/var/otcp/sites/images/node_43/node_51/node_77884/node_77888/tour-eiffel-tour-eiffel-illumin%C3%A9e-depuis-champs-de-mars-%C3%A9clairage-dor%C3%A9-%7C-630x405-%7C-%C2%A9-sete-emeric-livinec/21230551-1-fre-FR/Tour-Eiffel-Tour-Eiffel-illumin%C3%A9e-depuis-Champs-de-Mars-%C3%A9clairage-dor%C3%A9-%7C-630x405-%7C-%C2%A9-SETE-Emeric-Livinec.jpg"
                };

                Lieu ArcDeTriomphe = new Lieu
                {
                    Nom = "L'Arc de Triomphe",
                    Description = "Souhaité par Napoléon Ier dès 1806, l'Arc de triomphe est inauguré en 1836 par le roi des Français, Louis-Philippe, qui le dédie aux armées de la Révolution et de l'Empire. Le Soldat inconnu est inhumé sur le terre-plein en 1921.",
                    Ville = Paris,
                    Photo = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/79/Arc_de_Triomphe%2C_Paris_21_October_2010.jpg/420px-Arc_de_Triomphe%2C_Paris_21_October_2010.jpg"
                };

                Lieu Castillet = new Lieu
                {
                    Nom = "Le Castillet",
                    Description = "Le Castillet ou Castellet (en catalan) est un monument de la ville de Perpignan qui fut tour à tour porte de la ville et prison d'État. Aujourd'hui il abrite le Musée Catalan des Arts et Traditions Populaires (La Casa Pairal).",
                    Ville = Perpignan,
                    Photo = "https://img-4.linternaute.com/madSIX_h3NJmSdNTsZlt86aihTU=/1240x/smart/d3dd610a914048309792b52cba832152/ccmcms-linternaute/10625961.jpg"
                };

                Lieu PlazaDeArmas = new Lieu
                {
                    Nom = "La Plaza de Armas",
                    Description = "La Plaza de Armas est une place publique de la ville de Santiago, capitale du Chili.",
                    Ville = Santiago,
                    Photo = "https://upload.wikimedia.org/wikipedia/commons/3/3e/Plaza_de_Armas.JPG"
                };

                Lieu PalacioDeLaMoneda = new Lieu
                {
                    Nom = "Le Palacio de la Moneda",
                    Description = "Le Palacio de la Moneda, à Santiago, est le siège de la présidence du Chili et l'un des bâtiments les plus remarquables jamais construits par les Espagnols dans leurs colonies en Amérique latine.",
                    Ville = Santiago,
                    Photo = "https://e8s3v3w7.rocketcdn.me/wp-content/uploads/2017/11/chile-der-la-moneda-palast-in-santiago-de-chile-gary-yim-shutterstock.jpg"
                };
                Lieu BasiliqueSFA = new Lieu
                {
                    Nom = "Basilique et monastère Saint-François-d'Assise",
                    Description = "La basilique et le monastère Saint-François-d'Assise de Lima est un édifice catholique situé au nord-est de la Plaza Mayor, dans la ville de Lima, la capitale du Pérou. Avec le centre historique de Lima, il est inscrit sur la liste du Patrimoine mondial de l'UNESCO depuis 1991.",
                    Ville = Lima,
                    Photo = "https://aws-tiqets-cdn.imgix.net/images/content/4b1bb650b3ac4b3bb8925f8413138d90.jpg?auto=format&fit=crop&h=800&ixlib=python-3.2.1&q=70&w=800&s=4663a7e8e6ff19ddf479fad346e20db8"
                };
                Lieu ParqueDelAmor = new Lieu
                {
                    Nom = "Le Parque del Amor",
                    Description = "Tout au bout du quartier de Miraflores, en haut de la falaise qui fait face à la mer, le parc de l’amour est une jolie promenade longée par un mur en céramique coloré.",
                    Ville = Lima,
                    Photo = "https://www.machupicchu.com.pe/imagenes/lima/parque-del-amor/parque-amor.jpg"
                };

                Lieu PlaceBourse = new Lieu
                {
                    Nom = "La Place de la Bourse",
                    Description = "La place de la Bourse, initialement place Royale, est une place de Bordeaux, en France. Première place ouverte d'Europe, elle a été réalisée sous les intendances de Boucher et Tourny, par les architectes du roi Jacques Gabriel1 et son fils Ange-Jacques Gabriel, entre 1730 et 17552.",
                    Ville = Bordeaux,
                    Photo = "https://d1vp8nomjxwyf1.cloudfront.net/wp-content/uploads/sites/66/2016/12/07172835/Bordeaux-bourse.jpg"
                };

                Lieu SagradaFamilia = new Lieu
                {
                    Nom = "La Sagrada Familia",
                    Description = "La Sagrada Família, Temple Expiatori de la Sagrada Família de son nom complet en catalan, ou Templo Expiatorio de la Sagrada Familia en espagnol (en français : « temple expiatoire de la Sainte Famille ») est une basilique de Barcelone dont la construction a commencé en 1882.",
                    Ville = Barcelone,
                    Photo = "https://www.batiactu.com/images/auto/620-465-c/20211208_142724_illustration-sagrada-familia-recadree.jpg"
                };

                Lieu MuseePrado = new Lieu
                {
                    Nom = "Le Musée du Prado",
                    Description = "Le Musée du Prado est le musée le plus célèbre de Madrid et un des musées d'art les plus importants du monde. Il a été construit par Juan de Villanueva et a été inauguré en 1819.",
                    Ville = Madrid,
                    Photo = "data:image/jpeg;base64,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"
                };

                Lieu MuseeSantuarios = new Lieu
                {
                    Nom = "Musée des sanctuaires andins",
                    Description = "Le Musée des sanctuaires Andins abrite la momie de Juanita, princesse inca sacrifiée au pied du glacier Amparo et découverte en 1995 par une expédition menée par Johan Reinhard et Jose Antonio Chavez. L’émotion est au rendez-vous de la visite de ce petit musée où vous vous trouverez face à une fillette d’un autre temps..",
                    Ville = Arequipa,
                    Photo = "https://www.gpsmycity.com/img/gd_sight/43690.jpg"
                };

                Lieu Sotomayor = new Lieu
                {
                    Nom = "La Place Sotomayor",
                    Description = "C’est l’une des principales places de Valparaiso qui se trouve entre le quai Prat et la colline de la Cordillère, entourée par de nombreux bâtiments parmi lesquels se démarquent le bâtiment de la Marine chilienne, l’hôtel Queen Victoria et le monument de la Marine Nationale ou aux héros d’Iquique.",
                    Ville = Valparaiso,
                    Photo = "https://media-cdn.tripadvisor.com/media/photo-s/0d/93/5f/cd/plaza-sotomayor-monumento.jpg"
                };

                Lieu Cavancha = new Lieu
                {
                    Nom = "La Plage Cavancha",
                    Description = "Playa Cavancha est une sûre sablonneux plage dans Iquique. ",
                    Ville = Iquique,
                    Photo = "data:image/jpeg;base64,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"
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
                ParqueDelAmor,
                Castillet,
                GrandPlace,
                PlaceBourse,
                SagradaFamilia,
                MuseePrado,
                MuseeSantuarios,
                Sotomayor,
                Cavancha
                );

                Compte test = new Compte
                {
                    Nom = "Test",
                    Prenom = "Test2",
                    Mail = "test@ensc.fr",
                    MotDePasse = "12345",
                };
                context.Comptes.AddRange(test);

                Appreciation aptoureiffel = new Appreciation
                {
                    Commentaire = "J'ai adoré ce monument emblématique de Paris ! J'ai déjà hate d'y retourner",
                    Date = new DateTime(2022, 12, 20, 19, 0, 0),
                    Compte = test,
                    Lieu = TourEiffel,
                };
                context.Appreciations.AddRange(aptoureiffel);

                Visite vistoureiffel = new Visite
                {
                    Date = new DateTime(2022, 12, 19, 19, 0, 0),
                    Compte = test,
                    Lieu = TourEiffel,
                };

                Visite visboverie = new Visite
                {
                    Date = new DateTime(2022, 11, 19, 19, 0, 0),
                    Compte = test,
                    Lieu = TourEiffel,
                };

                Favori favboverie = new Favori
                {
                    Compte = test,
                    Lieu = TourEiffel,
                };

                context.Visites.AddRange(vistoureiffel, visboverie);
            }
            context.SaveChanges();
        }

    }

}