using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;

namespace Business
{
    public class DataContext : DbContext
    {
        public DataContext() : base("LunchDb") {}
   
        public DbSet<Company> Companies { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<LunchArea> LunchAreas { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<Advertise> Advertises { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuDay> MenuDays { get; set; }
        public DbSet<NameDay> NameDays { get; set; }
        public DbSet<Message> Messages { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<MenuDay>()
        //        .HasMany(n => n.Dishes)
        //        .WithRequired()
        //        .Map(conf => conf.MapKey("DishId"))
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Dish>()
        //        .HasOptional(a => a.MenuDay)
        //        //.HasRequired(a => a.toNation)
        //        .WithMany()
        //        .Map(conf => conf.MapKey("MenuDayId"))
        //        .WillCascadeOnDelete(false);
        //}

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Restaurant>()
        //        .HasRequired(e => e.Company)
        //        .WithMany(t => t.Restaurants)
        //        .HasForeignKey(e => e.CompanyId)
        //        .WillCascadeOnDelete(false);
        //}
    }

    public class DataContextInitializer : DropCreateDatabaseAlways<DataContext>
    {
        private DataContext db;
        protected override void Seed(DataContext dbb)
        {
            this.db = dbb;
            var companys = new List<Company> {
                new Company(false)
                    { Name = "Företagets namn test", Information = @"diverse information, etablsering etc..." }                       
            };
            var c = companys.First();
            db.Companies.Add(c);
            
            #region namesDays

            var namedays = new List<NameDay> {
                new NameDay { Key = "	1/1	", Names = "	Nyårsdagen	" },
                new NameDay { Key = "	2/1	", Names = "	Svea	" },
                new NameDay { Key = "	3/1	", Names = "	Alfred, Alfrida	" },
                new NameDay { Key = "	4/1	", Names = "	Rut	" },
                new NameDay { Key = "	5/1	", Names = "	Hanna, Hannele	" },
                new NameDay { Key = "	6/1	", Names = "	Kasper, Melker, Baltsar	" },
                new NameDay { Key = "	7/1	", Names = "	August, Augusta	" },
                new NameDay { Key = "	8/1	", Names = "	Erland	" },
                new NameDay { Key = "	9/1	", Names = "	Gunnar, Gunder	" },
                new NameDay { Key = "	10/1	", Names = "	Sigurd, Sigbritt	" },
                new NameDay { Key = "	11/1	", Names = "	Jan, Jannike	" },
                new NameDay { Key = "	12/1	", Names = "	Frideborg, Fridolf	" },
                new NameDay { Key = "	13/1	", Names = "	Knut	" },
                new NameDay { Key = "	14/1	", Names = "	Felix, Felicia	" },
                new NameDay { Key = "	15/1	", Names = "	Laura, Lorentz	" },
                new NameDay { Key = "	16/1	", Names = "	Hjalmar, Helmer	" },
                new NameDay { Key = "	17/1	", Names = "	Anton, Tony	" },
                new NameDay { Key = "	18/1	", Names = "	Hilda, Hildur	" },
                new NameDay { Key = "	19/1	", Names = "	Henrik	" },
                new NameDay { Key = "	20/1	", Names = "	Fabian, Sebastian	" },
                new NameDay { Key = "	21/1	", Names = "	Agnes, Agneta	" },
                new NameDay { Key = "	22/1	", Names = "	Vincent, Viktor	" },
                new NameDay { Key = "	23/1	", Names = "	Frej, Freja	" },
                new NameDay { Key = "	24/1	", Names = "	Erika	" },
                new NameDay { Key = "	25/1	", Names = "	Paul, Pål	" },
                new NameDay { Key = "	26/1	", Names = "	Bodil, Boel	" },
                new NameDay { Key = "	27/1	", Names = "	Göte, Göta	" },
                new NameDay { Key = "	28/1	", Names = "	Karl, Karla	" },
                new NameDay { Key = "	29/1	", Names = "	Diana	" },
                new NameDay { Key = "	30/1	", Names = "	Gunilla, Gunhild	" },
                new NameDay { Key = "	31/1	", Names = "	Ivar, Joar	" },
                new NameDay { Key = "	1/2	", Names = "	Max, Maximilian	" },
                new NameDay { Key = "	2/2	", Names = "	Kyndelsmässodagen	" },
                new NameDay { Key = "	3/2	", Names = "	Disa, Hjördis	" },
                new NameDay { Key = "	4/2	", Names = "	Ansgar, Anselm	" },
                new NameDay { Key = "	5/2	", Names = "	Agata, Agda	" },
                new NameDay { Key = "	6/2	", Names = "	Dorotea, Doris	" },
                new NameDay { Key = "	7/2	", Names = "	Rikard, Dick	" },
                new NameDay { Key = "	8/2	", Names = "	Berta, Bert	" },
                new NameDay { Key = "	9/2	", Names = "	Fanny, Franciska	" },
                new NameDay { Key = "	10/2	", Names = "	Iris	" },
                new NameDay { Key = "	11/2	", Names = "	Yngve, Inge	" },
                new NameDay { Key = "	12/2	", Names = "	Evelina, Evy	" },
                new NameDay { Key = "	13/2	", Names = "	Agne, Ove	" },
                new NameDay { Key = "	14/2	", Names = "	Valentin	" },
                new NameDay { Key = "	15/2	", Names = "	Sigfrid	" },
                new NameDay { Key = "	16/2	", Names = "	Julia, Julius	" },
                new NameDay { Key = "	17/2	", Names = "	Alexandra, Sandra	" },
                new NameDay { Key = "	18/2	", Names = "	Frida, Fritiof	" },
                new NameDay { Key = "	19/2	", Names = "	Gabriella, Ella	" },
                new NameDay { Key = "	20/2	", Names = "	Vivianne	" },
                new NameDay { Key = "	21/2	", Names = "	Hilding	" },
                new NameDay { Key = "	22/2	", Names = "	Pia	" },
                new NameDay { Key = "	23/2	", Names = "	Torsten, Torun	" },
                new NameDay { Key = "	24/2	", Names = "	Mattias, Mats	" },
                new NameDay { Key = "	25/2	", Names = "	Sigvard, Sivert	" },
                new NameDay { Key = "	26/2	", Names = "	Torgny, Torkel	" },
                new NameDay { Key = "	27/2	", Names = "	Lage	" },
                new NameDay { Key = "	28/2	", Names = "	Maria	" },
                new NameDay { Key = "	29/2	", Names = "	Skottdagen	" },
                new NameDay { Key = "	1/3	", Names = "	Albin, Elvira	" },
                new NameDay { Key = "	2/3	", Names = "	Ernst, Erna	" },
                new NameDay { Key = "	3/3	", Names = "	Gunborg, Gunvor	" },
                new NameDay { Key = "	4/3	", Names = "	Adrian, Adriana	" },
                new NameDay { Key = "	5/3	", Names = "	Tora, Tove	" },
                new NameDay { Key = "	6/3	", Names = "	Ebba, Ebbe	" },
                new NameDay { Key = "	7/3	", Names = "	Camilla	" },
                new NameDay { Key = "	8/3	", Names = "	Siv	" },
                new NameDay { Key = "	9/3	", Names = "	Torbjörn, Torleif	" },
                new NameDay { Key = "	10/3	", Names = "	Edla, Ada	" },
                new NameDay { Key = "	11/3	", Names = "	Edvin, Egon	" },
                new NameDay { Key = "	12/3	", Names = "	Viktoria	" },
                new NameDay { Key = "	13/3	", Names = "	Greger	" },
                new NameDay { Key = "	14/3	", Names = "	Matilda, Maud	" },
                new NameDay { Key = "	15/3	", Names = "	Kristoffer, Christel	" },
                new NameDay { Key = "	16/3	", Names = "	Herbert, Gilbert	" },
                new NameDay { Key = "	17/3	", Names = "	Gertrud	" },
                new NameDay { Key = "	18/3	", Names = "	Edvard, Edmund	" },
                new NameDay { Key = "	19/3	", Names = "	Josef, Josefina	" },
                new NameDay { Key = "	20/3	", Names = "	Joakim, Kim	" },
                new NameDay { Key = "	21/3	", Names = "	Bengt	" },
                new NameDay { Key = "	22/3	", Names = "	Kennet, Kent	" },
                new NameDay { Key = "	23/3	", Names = "	Gerda, Gerd	" },
                new NameDay { Key = "	24/3	", Names = "	Gabriel, Rafael	" },
                new NameDay { Key = "	25/3	", Names = "	Marie bebådelsedag	" },
                new NameDay { Key = "	26/3	", Names = "	Emanuel	" },
                new NameDay { Key = "	27/3	", Names = "	Rudolf, Ralf	" },
                new NameDay { Key = "	28/3	", Names = "	Malkolm, Morgan	" },
                new NameDay { Key = "	29/3	", Names = "	Jonas, Jens	" },
                new NameDay { Key = "	30/3	", Names = "	Holger, Holmfrid	" },
                new NameDay { Key = "	31/3	", Names = "	Ester	" },
                new NameDay { Key = "	1/4	", Names = "	Harald, Hervor	" },
                new NameDay { Key = "	2/4	", Names = "	Gudmund, Ingemund	" },
                new NameDay { Key = "	3/4	", Names = "	Ferdinand, Nanna	" },
                new NameDay { Key = "	4/4	", Names = "	Marianne, Marlene	" },
                new NameDay { Key = "	5/4	", Names = "	Irene, Irja	" },
                new NameDay { Key = "	6/4	", Names = "	Vilhelm, William	" },
                new NameDay { Key = "	7/4	", Names = "	Irma, Irmelin	" },
                new NameDay { Key = "	8/4	", Names = "	Nadja, Tanja	" },
                new NameDay { Key = "	9/4	", Names = "	Otto, Ottilia	" },
                new NameDay { Key = "	10/4	", Names = "	Ingvar, Ingvor	" },
                new NameDay { Key = "	11/4	", Names = "	Ulf, Ylva	" },
                new NameDay { Key = "	12/4	", Names = "	Liv	" },
                new NameDay { Key = "	13/4	", Names = "	Artur, Douglas	" },
                new NameDay { Key = "	14/4	", Names = "	Tiburtius	" },
                new NameDay { Key = "	15/4	", Names = "	Olivia, Oliver	" },
                new NameDay { Key = "	16/4	", Names = "	Patrik, Patricia	" },
                new NameDay { Key = "	17/4	", Names = "	Elias, Elis	" },
                new NameDay { Key = "	18/4	", Names = "	Valdemar, Volmar	" },
                new NameDay { Key = "	19/4	", Names = "	Olaus, Ola	" },
                new NameDay { Key = "	20/4	", Names = "	Amalia, Amelie	" },
                new NameDay { Key = "	21/4	", Names = "	Anneli, Annika	" },
                new NameDay { Key = "	22/4	", Names = "	Allan, Glenn	" },
                new NameDay { Key = "	23/4	", Names = "	Georg, Göran	" },
                new NameDay { Key = "	24/4	", Names = "	Vega	" },
                new NameDay { Key = "	25/4	", Names = "	Markus	" },
                new NameDay { Key = "	26/4	", Names = "	Teresia, Terese	" },
                new NameDay { Key = "	27/4	", Names = "	Engelbrekt	" },
                new NameDay { Key = "	28/4	", Names = "	Ture, Tyra	" },
                new NameDay { Key = "	29/4	", Names = "	Tyko	" },
                new NameDay { Key = "	30/4	", Names = "	Mariana, (Valborgsmässoafton)	" },
                new NameDay { Key = "	1/5	", Names = "	Valborg, (Första maj)	" },
                new NameDay { Key = "	2/5	", Names = "	Filip, Filippa	" },
                new NameDay { Key = "	3/5	", Names = "	John, Jane	" },
                new NameDay { Key = "	4/5	", Names = "	Monika, Mona	" },
                new NameDay { Key = "	5/5	", Names = "	Gotthard, Erhard	" },
                new NameDay { Key = "	6/5	", Names = "	Marit, Rita	" },
                new NameDay { Key = "	7/5	", Names = "	Carina, Carita	" },
                new NameDay { Key = "	8/5	", Names = "	Åke	" },
                new NameDay { Key = "	9/5	", Names = "	Reidar, Reidun	" },
                new NameDay { Key = "	10/5	", Names = "	Esbjörn, Styrbjörn	" },
                new NameDay { Key = "	11/5	", Names = "	Märta, Märit	" },
                new NameDay { Key = "	12/5	", Names = "	Charlotta, Lotta	" },
                new NameDay { Key = "	13/5	", Names = "	Linnea, Linn	" },
                new NameDay { Key = "	14/5	", Names = "	Halvard, Halvar	" },
                new NameDay { Key = "	15/5	", Names = "	Sofia, Sonja	" },
                new NameDay { Key = "	16/5	", Names = "	Ronald, Ronny	" },
                new NameDay { Key = "	17/5	", Names = "	Rebecka, Ruben	" },
                new NameDay { Key = "	18/5	", Names = "	Erik	" },
                new NameDay { Key = "	19/5	", Names = "	Maj, Majken	" },
                new NameDay { Key = "	20/5	", Names = "	Karolina, Carola	" },
                new NameDay { Key = "	21/5	", Names = "	Konstantin, Conny	" },
                new NameDay { Key = "	22/5	", Names = "	Hemming, Henning	" },
                new NameDay { Key = "	23/5	", Names = "	Desideria, Desirée	" },
                new NameDay { Key = "	24/5	", Names = "	Ivan, Vanja	" },
                new NameDay { Key = "	25/5	", Names = "	Urban	" },
                new NameDay { Key = "	26/5	", Names = "	Vilhelmina, Vilma	" },
                new NameDay { Key = "	27/5	", Names = "	Beda, Blenda	" },
                new NameDay { Key = "	28/5	", Names = "	Ingeborg, Borghild	" },
                new NameDay { Key = "	29/5	", Names = "	Yvonne, Jeanette	" },
                new NameDay { Key = "	30/5	", Names = "	Vera, Veronika	" },
                new NameDay { Key = "	31/5	", Names = "	Petronella, Pernilla	" },
                new NameDay { Key = "	1/6	", Names = "	Gun, Gunnel	" },
                new NameDay { Key = "	2/6	", Names = "	Rutger, Roger	" },
                new NameDay { Key = "	3/6	", Names = "	Ingemar, Gudmar	" },
                new NameDay { Key = "	4/6	", Names = "	Solbritt, Solveig	" },
                new NameDay { Key = "	5/6	", Names = "	Bo	" },
                new NameDay { Key = "	6/6	", Names = "	Gustav, Gösta	" },
                new NameDay { Key = "	7/6	", Names = "	Robert, Robin	" },
                new NameDay { Key = "	8/6	", Names = "	Eivor, Majvor	" },
                new NameDay { Key = "	9/6	", Names = "	Börje, Birger	" },
                new NameDay { Key = "	10/6	", Names = "	Svante, Boris	" },
                new NameDay { Key = "	11/6	", Names = "	Bertil, Berthold	" },
                new NameDay { Key = "	12/6	", Names = "	Eskil	" },
                new NameDay { Key = "	13/6	", Names = "	Aina, Aino	" },
                new NameDay { Key = "	14/6	", Names = "	Håkan, Hakon	" },
                new NameDay { Key = "	15/6	", Names = "	Margit, Margot	" },
                new NameDay { Key = "	16/6	", Names = "	Axel, Axelina	" },
                new NameDay { Key = "	17/6	", Names = "	Torborg, Torvald	" },
                new NameDay { Key = "	18/6	", Names = "	Björn, Bjarne	" },
                new NameDay { Key = "	19/6	", Names = "	Germund, Görel	" },
                new NameDay { Key = "	20/6	", Names = "	Linda	" },
                new NameDay { Key = "	21/6	", Names = "	Alf, Alvar	" },
                new NameDay { Key = "	22/6	", Names = "	Paulina, Paula	" },
                new NameDay { Key = "	23/6	", Names = "	Adolf, Alice	" },
                new NameDay { Key = "	24/6	", Names = "	Johannes Döparens dag	" },
                new NameDay { Key = "	25/6	", Names = "	David, Salomon	" },
                new NameDay { Key = "	26/6	", Names = "	Rakel, Lea	" },
                new NameDay { Key = "	27/6	", Names = "	Selma, Fingal	" },
                new NameDay { Key = "	28/6	", Names = "	Leo	" },
                new NameDay { Key = "	29/6	", Names = "	Peter, Petra	" },
                new NameDay { Key = "	30/6	", Names = "	Elof, Leif	" },
                new NameDay { Key = "	1/7	", Names = "	Aron, Mirjam	" },
                new NameDay { Key = "	2/7	", Names = "	Rosa, Rosita	" },
                new NameDay { Key = "	3/7	", Names = "	Aurora	" },
                new NameDay { Key = "	4/7	", Names = "	Ulrika, Ulla	" },
                new NameDay { Key = "	5/7	", Names = "	Laila, Ritva	" },
                new NameDay { Key = "	6/7	", Names = "	Esaias, Jessika	" },
                new NameDay { Key = "	7/7	", Names = "	Klas	" },
                new NameDay { Key = "	8/7	", Names = "	Kjell	" },
                new NameDay { Key = "	9/7	", Names = "	Jörgen, Örjan	" },
                new NameDay { Key = "	10/7	", Names = "	André, Andrea	" },
                new NameDay { Key = "	11/7	", Names = "	Eleonora, Ellinor	" },
                new NameDay { Key = "	12/7	", Names = "	Herman, Hermine	" },
                new NameDay { Key = "	13/7	", Names = "	Joel, Judit	" },
                new NameDay { Key = "	14/7	", Names = "	Folke	" },
                new NameDay { Key = "	15/7	", Names = "	Ragnhild, Ragnvald	" },
                new NameDay { Key = "	16/7	", Names = "	Reinhold, Reine	" },
                new NameDay { Key = "	17/7	", Names = "	Bruno	" },
                new NameDay { Key = "	18/7	", Names = "	Fredrik, Fritz	" },
                new NameDay { Key = "	19/7	", Names = "	Sara	" },
                new NameDay { Key = "	20/7	", Names = "	Margareta, Greta	" },
                new NameDay { Key = "	21/7	", Names = "	Johanna	" },
                new NameDay { Key = "	22/7	", Names = "	Magdalena, Madeleine	" },
                new NameDay { Key = "	23/7	", Names = "	Emma	" },
                new NameDay { Key = "	24/7	", Names = "	Kristina, Kerstin	" },
                new NameDay { Key = "	25/7	", Names = "	Jakob	" },
                new NameDay { Key = "	26/7	", Names = "	Jesper	" },
                new NameDay { Key = "	27/7	", Names = "	Marta	" },
                new NameDay { Key = "	28/7	", Names = "	Botvid, Seved	" },
                new NameDay { Key = "	29/7	", Names = "	Olof	" },
                new NameDay { Key = "	30/7	", Names = "	Algot	" },
                new NameDay { Key = "	31/7	", Names = "	Helena, Elin	" },
                new NameDay { Key = "	1/8	", Names = "	Per	" },
                new NameDay { Key = "	2/8	", Names = "	Karin, Kajsa	" },
                new NameDay { Key = "	3/8	", Names = "	Tage	" },
                new NameDay { Key = "	4/8	", Names = "	Arne, Arnold	" },
                new NameDay { Key = "	5/8	", Names = "	Ulrik, Alrik	" },
                new NameDay { Key = "	6/8	", Names = "	Alfons, Inez	" },
                new NameDay { Key = "	7/8	", Names = "	Dennis, Denise	" },
                new NameDay { Key = "	8/8	", Names = "	Silvia, Sylvia	" },
                new NameDay { Key = "	9/8	", Names = "	Roland	" },
                new NameDay { Key = "	10/8	", Names = "	Lars	" },
                new NameDay { Key = "	11/8	", Names = "	Susanna	" },
                new NameDay { Key = "	12/8	", Names = "	Klara	" },
                new NameDay { Key = "	13/8	", Names = "	Kaj	" },
                new NameDay { Key = "	14/8	", Names = "	Uno	" },
                new NameDay { Key = "	15/8	", Names = "	Stella, Estelle	" },
                new NameDay { Key = "	16/8	", Names = "	Brynolf	" },
                new NameDay { Key = "	17/8	", Names = "	Verner, Valter	" },
                new NameDay { Key = "	18/8	", Names = "	Ellen, Lena	" },
                new NameDay { Key = "	19/8	", Names = "	Magnus, Måns	" },
                new NameDay { Key = "	20/8	", Names = "	Bernhard, Bernt	" },
                new NameDay { Key = "	21/8	", Names = "	Jon, Jonna	" },
                new NameDay { Key = "	22/8	", Names = "	Henrietta, Henrika	" },
                new NameDay { Key = "	23/8	", Names = "	Signe, Signhild	" },
                new NameDay { Key = "	24/8	", Names = "	Bartolomeus	" },
                new NameDay { Key = "	25/8	", Names = "	Lovisa, Louise	" },
                new NameDay { Key = "	26/8	", Names = "	Östen	" },
                new NameDay { Key = "	27/8	", Names = "	Rolf, Raoul	" },
                new NameDay { Key = "	28/8	", Names = "	Fatima, Leila	" },
                new NameDay { Key = "	29/8	", Names = "	Hans, Hampus	" },
                new NameDay { Key = "	30/8	", Names = "	Albert, Albertina	" },
                new NameDay { Key = "	31/8	", Names = "	Arvid, Vidar	" },
                new NameDay { Key = "	1/9	", Names = "	Sam, Samuel	" },
                new NameDay { Key = "	2/9	", Names = "	Justus, Justina	" },
                new NameDay { Key = "	3/9	", Names = "	Alfhild, Alva	" },
                new NameDay { Key = "	4/9	", Names = "	Gisela	" },
                new NameDay { Key = "	5/9	", Names = "	Adela, Heidi	" },
                new NameDay { Key = "	6/9	", Names = "	Lilian, Lilly	" },
                new NameDay { Key = "	7/9	", Names = "	Kevin, Roy	" },
                new NameDay { Key = "	8/9	", Names = "	Alma, Hulda	" },
                new NameDay { Key = "	9/9	", Names = "	Anita, Annette	" },
                new NameDay { Key = "	10/9	", Names = "	Tord, Turid	" },
                new NameDay { Key = "	11/9	", Names = "	Dagny, Helny	" },
                new NameDay { Key = "	12/9	", Names = "	Åsa, Åslög	" },
                new NameDay { Key = "	13/9	", Names = "	Sture	" },
                new NameDay { Key = "	14/9	", Names = "	Ida	" },
                new NameDay { Key = "	15/9	", Names = "	Sigrid, Siri	" },
                new NameDay { Key = "	16/9	", Names = "	Dag, Daga	" },
                new NameDay { Key = "	17/9	", Names = "	Hildegard, Magnhild	" },
                new NameDay { Key = "	18/9	", Names = "	Orvar	" },
                new NameDay { Key = "	19/9	", Names = "	Fredrika	" },
                new NameDay { Key = "	20/9	", Names = "	Elise, Lisa	" },
                new NameDay { Key = "	21/9	", Names = "	Matteus	" },
                new NameDay { Key = "	22/9	", Names = "	Maurits, Moritz	" },
                new NameDay { Key = "	23/9	", Names = "	Tekla, Tea	" },
                new NameDay { Key = "	24/9	", Names = "	Gerhard, Gert	" },
                new NameDay { Key = "	25/9	", Names = "	Tryggve	" },
                new NameDay { Key = "	26/9	", Names = "	Enar, Einar	" },
                new NameDay { Key = "	27/9	", Names = "	Dagmar, Rigmor	" },
                new NameDay { Key = "	28/9	", Names = "	Lennart, Leonard	" },
                new NameDay { Key = "	29/9	", Names = "	Mikael, Mikaela	" },
                new NameDay { Key = "	30/9	", Names = "	Helge	" },
                new NameDay { Key = "	1/10	", Names = "	Ragnar, Ragna	" },
                new NameDay { Key = "	2/10	", Names = "	Ludvig, Love	" },
                new NameDay { Key = "	3/10	", Names = "	Evald, Osvald	" },
                new NameDay { Key = "	4/10	", Names = "	Frans, Frank	" },
                new NameDay { Key = "	5/10	", Names = "	Bror	" },
                new NameDay { Key = "	6/10	", Names = "	Jenny, Jennifer	" },
                new NameDay { Key = "	7/10	", Names = "	Birgitta, Britta	" },
                new NameDay { Key = "	8/10	", Names = "	Nils	" },
                new NameDay { Key = "	9/10	", Names = "	Ingrid, Inger	" },
                new NameDay { Key = "	10/10	", Names = "	Harry, Harriet	" },
                new NameDay { Key = "	11/10	", Names = "	Erling, Jarl	" },
                new NameDay { Key = "	12/10	", Names = "	Valfrid, Manfred	" },
                new NameDay { Key = "	13/10	", Names = "	Berit, Birgit	" },
                new NameDay { Key = "	14/10	", Names = "	Stellan	" },
                new NameDay { Key = "	15/10	", Names = "	Hedvig, Hillevi	" },
                new NameDay { Key = "	16/10	", Names = "	Finn	" },
                new NameDay { Key = "	17/10	", Names = "	Antonia, Toini	" },
                new NameDay { Key = "	18/10	", Names = "	Lukas	" },
                new NameDay { Key = "	19/10	", Names = "	Tore, Tor	" },
                new NameDay { Key = "	20/10	", Names = "	Sibylla	" },
                new NameDay { Key = "	21/10	", Names = "	Ursula, Yrsa	" },
                new NameDay { Key = "	22/10	", Names = "	Marika, Marita	" },
                new NameDay { Key = "	23/10	", Names = "	Severin, Sören	" },
                new NameDay { Key = "	24/10	", Names = "	Evert, Eilert	" },
                new NameDay { Key = "	25/10	", Names = "	Inga, Ingalill	" },
                new NameDay { Key = "	26/10	", Names = "	Amanda, Rasmus	" },
                new NameDay { Key = "	27/10	", Names = "	Sabina	" },
                new NameDay { Key = "	28/10	", Names = "	Simon, Simone	" },
                new NameDay { Key = "	29/10	", Names = "	Viola	" },
                new NameDay { Key = "	30/10	", Names = "	Elsa, Isabella	" },
                new NameDay { Key = "	31/10	", Names = "	Edit, Edgar	" },
                new NameDay { Key = "	1/11	", Names = "	Allhelgonadagen	" },
                new NameDay { Key = "	2/11	", Names = "	Tobias	" },
                new NameDay { Key = "	3/11	", Names = "	Hubert, Hugo	" },
                new NameDay { Key = "	4/11	", Names = "	Sverker	" },
                new NameDay { Key = "	5/11	", Names = "	Eugen, Eugenia	" },
                new NameDay { Key = "	6/11	", Names = "	Gustav Adolf	" },
                new NameDay { Key = "	7/11	", Names = "	Ingegerd, Ingela	" },
                new NameDay { Key = "	8/11	", Names = "	Vendela	" },
                new NameDay { Key = "	9/11	", Names = "	Teodor, Teodora	" },
                new NameDay { Key = "	10/11	", Names = "	Martin, Martina	" },
                new NameDay { Key = "	11/11	", Names = "	Mårten	" },
                new NameDay { Key = "	12/11	", Names = "	Konrad, Kurt	" },
                new NameDay { Key = "	13/11	", Names = "	Kristian, Krister	" },
                new NameDay { Key = "	14/11	", Names = "	Emil, Emilia	" },
                new NameDay { Key = "	15/11	", Names = "	Leopold	" },
                new NameDay { Key = "	16/11	", Names = "	Vibeke, Viveka	" },
                new NameDay { Key = "	17/11	", Names = "	Naemi, Naima	" },
                new NameDay { Key = "	18/11	", Names = "	Lillemor, Moa	" },
                new NameDay { Key = "	19/11	", Names = "	Elisabet, Lisbet	" },
                new NameDay { Key = "	20/11	", Names = "	Pontus, Marina	" },
                new NameDay { Key = "	21/11	", Names = "	Helga, Olga	" },
                new NameDay { Key = "	22/11	", Names = "	Cecilia, Sissela	" },
                new NameDay { Key = "	23/11	", Names = "	Klemens	" },
                new NameDay { Key = "	24/11	", Names = "	Gudrun, Rune	" },
                new NameDay { Key = "	25/11	", Names = "	Katarina, Katja	" },
                new NameDay { Key = "	26/11	", Names = "	Linus	" },
                new NameDay { Key = "	27/11	", Names = "	Astrid, Asta	" },
                new NameDay { Key = "	28/11	", Names = "	Malte	" },
                new NameDay { Key = "	29/11	", Names = "	Sune	" },
                new NameDay { Key = "	30/11	", Names = "	Andreas, Anders	" },
                new NameDay { Key = "	1/12	", Names = "	Oskar, Ossian	" },
                new NameDay { Key = "	2/12	", Names = "	Beata, Beatrice	" },
                new NameDay { Key = "	3/12	", Names = "	Lydia	" },
                new NameDay { Key = "	4/12	", Names = "	Barbara, Barbro	" },
                new NameDay { Key = "	5/12	", Names = "	Sven	" },
                new NameDay { Key = "	6/12	", Names = "	Nikolaus, Niklas	" },
                new NameDay { Key = "	7/12	", Names = "	Angela, Angelika	" },
                new NameDay { Key = "	8/12	", Names = "	Virginia	" },
                new NameDay { Key = "	9/12	", Names = "	Anna	" },
                new NameDay { Key = "	10/12	", Names = "	Malin, Malena	" },
                new NameDay { Key = "	11/12	", Names = "	Daniel, Daniela	" },
                new NameDay { Key = "	12/12	", Names = "	Alexander, Alexis	" },
                new NameDay { Key = "	13/12	", Names = "	Lucia	" },
                new NameDay { Key = "	14/12	", Names = "	Sten, Sixten	" },
                new NameDay { Key = "	15/12	", Names = "	Gottfrid	" },
                new NameDay { Key = "	16/12	", Names = "	Assar	" },
                new NameDay { Key = "	17/12	", Names = "	Stig	" },
                new NameDay { Key = "	18/12	", Names = "	Abraham	" },
                new NameDay { Key = "	19/12	", Names = "	Isak	" },
                new NameDay { Key = "	20/12	", Names = "	Israel, Moses	" },
                new NameDay { Key = "	21/12	", Names = "	Tomas	" },
                new NameDay { Key = "	22/12	", Names = "	Natanael, Jonatan	" },
                new NameDay { Key = "	23/12	", Names = "	Adam	" },
                new NameDay { Key = "	24/12	", Names = "	Eva, (Julafton)	" },
                new NameDay { Key = "	25/12	", Names = "	Juldagen	" },
                new NameDay { Key = "	26/12	", Names = "	Stefan, Staffan, (Annandag jul)	" },
                new NameDay { Key = "	27/12	", Names = "	Johannes, Johan	" },
                new NameDay { Key = "	28/12	", Names = "	Benjamin, (Värnlösa barns dag)	" },
                new NameDay { Key = "	29/12	", Names = "	Natalia, Natalie	" },
                new NameDay { Key = "	30/12	", Names = "	Abel, Set	" },
                new NameDay { Key = "	31/12	", Names = "	Sylvester	" }
                               };
            foreach (var nameday in namedays)
            {
                nameday.Key = nameday.Key.Trim();
                nameday.Names = nameday.Names.Trim();
                db.NameDays.Add(nameday);
            }
            db.SaveChanges();
            #endregion


            #region rests

            var restaurants = new List<Restaurant> {
             new Restaurant("	Väderstad Centralkrog	", "	0142-70667	", @"Lunch serveras mån-fre mellan kl. 11:00-15:00 Pris: 82-90kr. Inkl. Måltidsdryck, smör, bröd, salladsbuffé samt soppa. Avhämtning 68:- måltidsdryck, smör, bröd, & salladsbuffé ingår.
 Lunch på jobbet! Beställ maten innan kl. 9:00 
För mer info ring. Tel: 0142-70667 
www.centralkrogen.se - info@centralkrogen.se "	, @"	http://www.hitta.se/p/vaderstad-central-krog-ab/HAa8kC9Q8haKficmSB9YEQ_l__l_/?vad=0142-70667&Vkid=19920900&isAlternateNumberResult=False	"),
new Restaurant("	Kvarnparken	", "	0142-16900	", @"Lunch serveras som buffé (80kr inkl. sill & stort salladsbord) Dryck, kaffe & sallad ingår. Lunch mellan 11.30-13:30.
 Måndag-torsdag: 2 rätter. Fredagar: 1 rätt + dessert. Lunchkuponger: 11 biljetter för 800kr. Avhämtning: 65kr (exkl. dryck & dessert). Boka bord på: 0142-16900."	, @"	http://kartor.eniro.se/query?what=map&mop=l6&streetname=&streetnumber=&city=&zipcode=&mapstate=5;1460159;6466785;0;1457401;6469195;1462919;6464377;&mapcomp=19299520;;Kvarnparken;Kullabergsg.;2;Box+73;59521;MJ%D6LBY;0142;169+00;;;1460159;6466790;1;1&search	"),
new Restaurant("	Golfrestaurangen - Helenas Kök & Catering	", null, @"Öppet året runt för lunch, beställningar & catering. Lunch kl. 11:30-14:30 Lunchbuffé m. dagens rätt, soppa, sallader, smör & bröd, kaffe & kaka 75:- Dagens färska fisk 90:- (inkl. soppa, sallad, smör, bröd, dryck, kaffe & kaka). All mat som serveras är i regel både gluten & laktosfri. Lilla matsalen tillgänglig för affärslunch, lunchmöten, beställningar, minnesstunder m.m. boka på tel: 0706-33 59 67. Catering alla dagar (m. några helgdagar som undantag). Mer information på vår hemsida www.helenasrestauranger.se 0706-33 59 67, Blixberg Miskarp" 	, @"	http://www.hitta.se/ViewDetailsPink.aspx?vad=mj%f6lby+golfklubb&Vkiid=I0GOLl7RV2yKS8%252fbGetKRQ%253d%253d&Vkid=1480434&isAlternateNumberResult=False	"),
new Restaurant("	Nils Dacke	", "	0142-850 32	", @"Lunch serveras mellan 11:30-13:00. 
Lunchpris 65:- (inkl. entrétallrik/soppa/salladsbord, smör, bröd, dryck, kaffe och kaka).
 Kuponghäfte, 10 st för 600:- 
Boka bord: 0142-850 32."	, @"http://kartor.eniro.se/query?what=map&mop=l6&streetname=&streetnumber=&city=&zipcode=&mapstate=5;1459705;6467388;0;1456948;6469799;1462465;6464980;&mapcomp=4674106;;Restaurang+Nils+Dacke;Burensk%F6ldsv.+;33;;59532;MJ%D6LBY;0142;850+32;;;1459705.0;6467388.	"),
new Restaurant("	Sissi´s kinesiska hemlagade mat	", "	0142-12391	", @"Lunch serveras må-fr 11:00-15:00 Pris: 80-99kr. I lunchen ingår även: Kimchi, räkchips, vårrullar, snacks, godis, dryck & kaffe, samt soppa (i vinter). Tel: 0142-12391"	, @"	http://www.hitta.se/karta?ref=start#var=Lundbygatan%2012%20A&from=1&pageCount=20&level=1&sm=6&center=6467123:1459761&type=map&zl=8&bounds=6466648:1458684,6467600:1460836	"),
new Restaurant("	Albackens Trädgårdskafferi	", "	0142-10991	", @"Pris 75 kr. Inkl. sallad, bröd, dricka, kaffe & kaka. Veckans paj ingår i dagens lunchpris. Lunch vardagar 11:30-14:00
 Öppet: Mån-fre 10-18, lör 10-16, sön 12-16 Tel. 0142-10991 0733-593059 info@albacken.net www.albacken.net          
 "	, @"		"),
new Restaurant("	Café Nyfiket	", "	0142-10586	", @"Lunch serveras kl. 11-14, pris 75 kr inkl. dryck & kaffe. Tel. 0142-10586. Möjlighet att hyra mindre konferensrum (10-12 sittplatser), vi tillhandahåller önskad förtäring.
 Vi fixar även catering, minnesstunder m.m. Du hittar oss på Kungsvägen 59. Handikappsanpassat & m. fullständiga rättigheter av alkohol.
 "	, @"	http://gulasidorna.eniro.se/f/café-nyfiket:14882580?geo_area=mj%C3%B6lby&search_word=cafe%20nyfiket	"),
new Restaurant("	Skånska Lasse	", "	0142-12410	", @"Lunch serveras mellan 11.00-15.00. Pris 75:- inkl. bröd, smör, salladsbuffé, dryck, kaffe & kaka. Lunchkuponger (11st) 750:-
 Pris avhämtning inkl. allt 65:- Häfte avhämtning (11st) inkl allt 650:- 
Varje dag har vi en stående a l? carte (87:-) meny m. Snitzel, Nötbit, Spätta, Hamburgare, Vegetariskt även Sallader (80:-)
 Café m. lättare luncher & hembakade bakverk. Tel: 0142-12410"	, @"http://gulasidorna.eniro.se/query?what=cs&search_word=sk%E5nska+lasse&geo_area=mj%F6lby	"),
new Restaurant("	Lunchterminalen	", "	Tel: 0142-14000	", @"Lunchbuffé serveras 11:30-14:00. Pris 78:- (kupongpris 780:- för 11 luncher). Avhämtning 65:-
 Klicka på ""Karta"" för att komma till vår hemsida m. mer information om oss. Tel: 0142-14000
 "	, @"	http://www.lunchterminalen.se	"),
new Restaurant("	Café Gusto	", "	0142-12728	", @"Lunch mellan 11:00-14:00. Samtliga rätter serveras m. sallad och bröd. Dryck och kaffe ingår. Pris 75:-
 Telefon: 0142-12728 www.cafegusto.se"	, @"http://www.hitta.se/ViewDetailsPink.aspx?vad=cafe+gusto&var=Mj%f6lby&Vkiid=OhzhG%2fCEkoWo%2fj%2fAQ8V3CQ%3d%3d&Vkid=14029932&isAlternateNumberResult=False	"),
new Restaurant("	På Lunch	", "	0142-12065	", @"Lunch serveras mellan 11:00-15:00 Du får välja på kokt eller stekt potatis, ris, bulgur & flera såser till lunchen. Självplock! Pris: Dagens lunch 75kr, (inkl. stor sallads buffé, dricka, bröd, smör, kaffe & kaka) avhämtning 75kr & buffé (ät så mycket du vill) 99kr. Lunchkuponger (11st) 750kr. Tel: 0142-120 65 Adress: St. Torget 2D. Välkomna!"	, @"	http://www.hitta.se/ViewDetailsPink.aspx?vad=p%e5+lunch&var=Mj%f6lby&Vkiid=QmSJRXbgo%2feyM879%2fIn2IA%3d%3d&Vkid=15755752&isAlternateNumberResult=False	"),
new Restaurant("	Industricafét	", "	0142-15958 	", @"Lunch serveras kl.11.30-13.30, som buffé med salladsbord inkl.bröd & kaffe. 
Pris: 65 kr, avhämtning 60 kr 
Varje dag finns även olika sallader & pastasallader. 
Lunchkort: 11 st lunch servering 650 kr, 11 st lunch avhämtning 600 kr 
Adress: Svänggatan 10 Telefon: 0142-15958               "	, @"	http://www.hitta.se/ViewDetailsPink.aspx?vad=industricaf%e9t&var=Mj%f6lby&Vkiid=6m9PtPOHDQD36hm4n3UGPw%3d%3d&Vkid=15636411&isAlternateNumberResult=False	"),
new Restaurant("	Eataliano & Asian	", "", "Öppet alla dagar 10-22, buffé 99:- alt. en rätt 69:- inkl. dryck, kaffe, sallad & efterrätt. Ni hittar oss på Viringeområdet i Mjölby!", @"		"),
new Restaurant("	Mandarin	", "	0142-17700	", @"Lunch serveras mellan 11:00-15:00, pris 75:- inkl. sallad, dryck, smör, bröd & kaffe. Lunchkuponger 10st 650:-
 Dessutom varje lunch: Kyckling-, bacon- el. tacopaj inkl. sallad, bröd, dryck & kaffe 65:-
 Tel: 0142-17700", "")
                
            };
            
            #endregion

            var l1 = new LunchArea { LunchAreaStatus = LunchAreaStatus.Active, Name = "Mjölby", Url = "mjolbylunch.se", Description = "Dagens lunch i Mjölby med omnejd"};
            var l2 = new LunchArea { LunchAreaStatus = LunchAreaStatus.New, Name = "Motala", Url = "motalalunch.se", Description = "Dagens lunch i Motala med omnejd" };
            var l3 = new LunchArea { LunchAreaStatus = LunchAreaStatus.Inactive, Name = "Linköping", Url = "linköpinglunch.se", Description = "Dagens lunch i Linköping" };
            db.LunchAreas.Add(l1);
            db.LunchAreas.Add(l2);
            db.LunchAreas.Add(l3);
            db.SaveChanges();

            #region adds
            
            var adds = new List<Advertise> {
               new Advertise() {Company = new Company() {Name = "Blåklintsbuss AB", Url = "http://mjolbylunch.se", Information = "Lite företagsinfo..." }, ImageUrl = 
                    "blaklintsbuss_20120929.gif", LunchArea = l1 },
                    new Advertise() {Company = new Company() {Name = "Jockes", Url = "http://mjolbylunch.se", Information = "Lite företagsinfo..." }, ImageUrl = 
                    "jockes_20091112.gif" , LunchArea = l1 },
                    new Advertise() {Company = new Company() {Name = "Bostadsbolaet AB", Url = "http://mjolbylunch.se", Information = "Lite företagsinfo..." }, ImageUrl = 
                    "bostadsbolaget_20110916.gif" , LunchArea = l1 },
                    new Advertise() {Company = new Company() {Name = "1Blåklintsbuss AB", Url = "http://mjolbylunch.se", Information = "Lite företagsinfo..." }, ImageUrl = 
                    "mse_20091108.gif" , LunchArea = l1 },
                    new Advertise() {Company = new Company() {Name = "2Blåklintsbuss AB", Url = "http://mjolbylunch.se", Information = "Lite företagsinfo..." }, ImageUrl = 
                    "elda_20120323.gif" , LunchArea = l1 },
                    new Advertise() {Company = new Company() {Name = "3Blåklintsbuss AB", Url = "http://mjolbylunch.se", Information = "Lite företagsinfo..." }, ImageUrl = 
                    "mjolbycity_20111031.gif" , LunchArea = l1 },
                    new Advertise() {Company = new Company() {Name = "4Blåklintsbuss AB", Url = "http://mjolbylunch.se", Information = "Lite företagsinfo..." }, ImageUrl = 
                    "honhan_20110401.gif" , LunchArea = l1 },
                    new Advertise() {Company = new Company() {Name = "5Blåklintsbuss AB", Url = "http://mjolbylunch.se", Information = "Lite företagsinfo..." }, ImageUrl = 
                    "blaklintsbuss_20120929.gif" , LunchArea = l1 },
                    new Advertise() {Company = new Company() {Name = "6Blåklintsbuss AB", Url = "http://mjolbylunch.se", Information = "Lite företagsinfo..." }, ImageUrl = 
                    "jockes_20091112.gif" , LunchArea = l1 },
                    new Advertise() {Company = new Company() {Name = "7Blåklintsbuss AB", Url = "http://mjolbylunch.se", Information = "Lite företagsinfo..." }, ImageUrl = 
                    "bostadsbolaget_20110916.gif" , LunchArea = l1 },
                    new Advertise() {Company = new Company() {Name = "8Blåklintsbuss AB", Url = "http://mjolbylunch.se", Information = "Lite företagsinfo..." }, ImageUrl = 
                    "mjolbycity_20111031.gif" , LunchArea = l1 },
                    new Advertise() {Company = new Company() {Name = "9Blåklintsbuss AB", Url = "http://mjolbylunch.se", Information = "Lite företagsinfo..." }, ImageUrl = 
                    "honhan_20110401.gif" , LunchArea = l1 },
                    new Advertise() {Company = new Company() {Name = "12Blåklintsbuss AB", Url = "http://mjolbylunch.se", Information = "Lite företagsinfo..." }, ImageUrl = 
                    "mse_20091108.gif" , LunchArea = l1 },
                    new Advertise() {Company = new Company() {Name = "22Blåklintsbuss AB", Url = "http://mjolbylunch.se", Information = "Lite företagsinfo..." }, ImageUrl = 
                    "elda_20120323.gif" , LunchArea = l1 },
                    new Advertise() {Company = new Company() {Name = "33Blåklintsbuss AB", Url = "http://mjolbylunch.se", Information = "Lite företagsinfo..." }, ImageUrl = 
                    "bostadsbolaget_20110916.gif" , LunchArea = l1 },
                    new Advertise() {Company = new Company() {Name = "44Blåklintsbuss AB", Url = "http://mjolbylunch.se", Information = "Lite företagsinfo..." }, ImageUrl = 
                    "mse_20091108.gif" , LunchArea = l1 },
                    new Advertise() {Company = new Company() {Name = "55Blåklintsbuss AB", Url = "http://mjolbylunch.se", Information = "Lite företagsinfo..." }, ImageUrl = 
                    "elda_20120323.gif" , LunchArea = l1 },
                    new Advertise() {Company = new Company() {Name = "66Blåklintsbuss AB", Url = "http://mjolbylunch.se", Information = "Lite företagsinfo..." }, ImageUrl = 
                    "mjolbycity_20111031.gif" , LunchArea = l1 },
                    new Advertise() {Company = new Company() {Name = "77Blåklintsbuss AB", Url = "http://mjolbylunch.se", Information = "Lite företagsinfo..." }, ImageUrl = 
                    "honhan_20110401.gif" , LunchArea = l1 },
                    new Advertise() {Company = new Company() {Name = "88Blåklintsbuss AB", Url = "http://mjolbylunch.se", Information = "Lite företagsinfo..." }, ImageUrl = 
                    "blaklintsbuss_20120929.gif" , LunchArea = l1 },
                    new Advertise() {Company = new Company() {Name = "99Blåklintsbuss AB", Url = "http://mjolbylunch.se", Information = "Lite företagsinfo..." }, ImageUrl = 
                    "jockes_20091112.gif" , LunchArea = l1 },
                    new Advertise() {Company = new Company() {Name = "345Blåklintsbuss AB", Url = "http://mjolbylunch.se", Information = "Lite företagsinfo..." }, ImageUrl = 
                    "bostadsbolaget_20110916.gif" , LunchArea = l1 },
                    new Advertise() {Company = new Company() {Name = "233Blåklintsbuss AB", Url = "http://mjolbylunch.se", Information = "Lite företagsinfo..." }, ImageUrl = 
                    "mjolbycity_20111031.gif" , LunchArea = l1 },
                    new Advertise() {Company = new Company() {Name = "1111Blåklintsbuss AB", Url = "http://mjolbylunch.se", Information = "Lite företagsinfo..." }, ImageUrl = 
                    "honhan_20110401.gif" , LunchArea = l1 },
                    new Advertise() {Company = new Company() {Name = "1212Blåklintsbuss AB", Url = "http://mjolbylunch.se", Information = "Lite företagsinfo..." }, ImageUrl = 
                    "mse_20091108.gif" , LunchArea = l1 },
                    new Advertise() {Company = new Company() {Name = "12121Blåklintsbuss AB", Url = "http://mjolbylunch.se", Information = "Lite företagsinfo..." }, ImageUrl = 
                    "elda_20120323.gif" , LunchArea = l1 }
                };

            foreach (var advertise in adds)
            {
                db.Advertises.Add(advertise);
            }
            db.SaveChanges();

            #endregion

            restaurants.First().Company = c;
            foreach (var restaurant in restaurants)
            {
                var cmp = new Company { Name = restaurant.Name };
                db.Companies.Add(cmp);
                restaurant.Company = cmp;
                db.Restaurants.Add(restaurant);
                restaurant.Areas.Add(l1);
                restaurant.Dishes = CreateDishes(restaurant);
            }
            db.SaveChanges();

            foreach (var restaurant in restaurants)
            {
                var weeknr = CalendarManager.GetCurrentWeek();
                var now = DateTime.Now.Year;
                var dayOneDishes = restaurant.Dishes.Take(3).ToList();
                var menu = new Menu
                               {
                                   Year = now,
                                   Week = weeknr,
                                   Info = string.Format("Information för menun som gäller för vecka {0} ", weeknr),
                                   Days = new List<MenuDay>()
                                              {
                                                  new MenuDay() { DayOfWeek = DayOfWeek.Monday, Dishes = dayOneDishes },
                                                  new MenuDay() { DayOfWeek = DayOfWeek.Tuesday, Dishes = dayOneDishes },
                                                  new MenuDay() { DayOfWeek = DayOfWeek.Wednesday, Dishes = dayOneDishes },
                                                  new MenuDay() { DayOfWeek = DayOfWeek.Thursday, Dishes = dayOneDishes, Message = "Ett erbjudande för idag!!"},
                                                  new MenuDay() { DayOfWeek = DayOfWeek.Friday, Dishes = dayOneDishes }
                                              }
                               };

                restaurant.Menus.Add(menu);
                db.Menus.Add(menu);
                foreach (var day in menu.Days)
                {
                    db.MenuDays.Add(day);
                }
            }
            db.SaveChanges();
        }

        private static List<Dish> CreateDishes(Restaurant r)
        {
            var d = new List<Dish>
            {
                new Dish() {ShortName = "Schnitzel", Description = "Ost & skinkfylld schnitzel med bearnaisesås, rödvinssås och klyftpotatis", Restaurant = r},
                new Dish() {ShortName = "Lax", Description = "Kräftgratinerad laxfilé med vitvinsås och kokt potatis", Restaurant = r, DishType=DishType.Fisk },
                new Dish() {ShortName = "Kyckling", Description = "Flygande Jacob serveras med ris", Restaurant = r, KitchenType = KitchenType.SvensktOchNordiskt, DishType=DishType.Gryta},
                new Dish() {ShortName = "Pasta", Description = "Lasagne al forno med vitlöksbröd", Restaurant = r, DishType = DishType.Pasta, KitchenType=KitchenType.Italienskt},
                new Dish() {ShortName = "Vegetarisk", Description = "Fylld gratinerad zucchini med grönsaksris och ört creme", Restaurant = r}, 
                new Dish() {ShortName = "Sallad", Description = "Räksallad med kokt ägg, sparris och rhode island ", Restaurant = r},
                
                //new Dish() {ShortName = "Schnitzel", Description = "Ost & skinkfylld schnitzel med bearnaisesås, rödvinssås och klyftpotatis"},
                //new Dish() {ShortName = "Lax", Description = "Kräftgratinerad laxfilé med vitvinsås och kokt potatis", DishType=DishType.Fisk },
                //new Dish() {ShortName = "Kyckling", Description = "Flygande Jacob serveras med ris", KitchenType = KitchenType.SvensktOchNordiskt, DishType=DishType.Gryta},
                //new Dish() {ShortName = "Pasta", Description = "Lasagne al forno med vitlöksbröd",  DishType = DishType.Pasta, KitchenType=KitchenType.Italienskt},
                //new Dish() {ShortName = "Vegetarisk", Description = "Fylld gratinerad zucchini med grönsaksris och ört creme", }, 
                //new Dish() {ShortName = "Sallad", Description = "Räksallad med kokt ägg, sparris och rhode island "},
            };
            return d;
        }
    }
}
