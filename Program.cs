using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportEmplacementEasylogistic
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Model.F_DEPOT> Depots = Model.F_DEPOT.List();

            foreach(Model.F_DEPOT Depot in Depots)
            {
                Console.WriteLine($"Traitement en cours du dépot : {Depot.DE_Intitule}");

                List<Model.F_ARTSTOCK> ArticlesStock = Model.F_ARTSTOCK.List(Depot.DE_No);
                List<Model.F_GAMSTOCK> ArticlesGamStock = Model.F_GAMSTOCK.List(Depot.DE_No);

                foreach(Model.F_ARTSTOCK article in ArticlesStock)
                {
                    if(article.DP_NoPrincipal != 0)
                    {
                        Console.WriteLine($"Traitement en cours de l'article : {article.ar_ref}");
                        Model.F_DEPOTEMPL emplacementSage = Model.F_DEPOTEMPL.ReadEmpl(Depot.DE_No, article.DP_NoPrincipal);

                        Model.Emplacements emplacementEasy = Model.Emplacements.ReadDepotEmplacement(Depot.DE_No, emplacementSage.DP_Code);

                        if(emplacementEasy != null)
                        {
                            Model.EmplacementArticle emplacementPrincipal = Model.EmplacementArticle.ReadEmplacementArticle(Depot.DE_No, article.ar_ref, 0, 0);
                            if(emplacementPrincipal != null)
                            {
                                emplacementPrincipal.DP_NoPrincipal = emplacementEasy.DP_No;
                                emplacementPrincipal.SaveDP_NoPrincipal();
                            } else
                            {
                                emplacementPrincipal = new Model.EmplacementArticle();
                                emplacementPrincipal.DP_NoPrincipal = emplacementEasy.DP_No;
                                emplacementPrincipal.DE_No = Depot.DE_No;
                                emplacementPrincipal.AR_Ref = article.ar_ref;
                                emplacementPrincipal.AG_No1 = 0;
                                emplacementPrincipal.AG_No2 = 0;
                                emplacementPrincipal.Add();
                            }
                        } else
                        {
                            Model.Emplacements empl = new Model.Emplacements();

                            empl.DE_No = Depot.DE_No;
                            empl.DP_Code = emplacementSage.DP_Code;
                            empl.DP_Intitule = emplacementSage.DP_Intitule;
                            empl.DP_Zone = null;
                            empl.DP_CapaciteMax = 0;
                            empl.DP_Hauteur = 0;
                            empl.DP_Largeur = 0;
                            empl.DP_Profondeur = 0;
                            empl.DP_Type = 0;
                            empl.DP_Position = 0;
                            empl.DP_PoidsMax = 0;
                            empl.Add();


                            Model.Emplacements emplInsertion = Model.Emplacements.ReadDepotEmplacement(Depot.DE_No, empl.DP_Code);

                            Model.EmplacementArticle emplacementPrincipal = Model.EmplacementArticle.ReadEmplacementArticle(Depot.DE_No, article.ar_ref, 0, 0);
                            if(emplacementPrincipal != null)
                            {
                                emplacementPrincipal.DP_NoPrincipal = emplInsertion.DP_No;
                                emplacementPrincipal.SaveDP_NoPrincipal();
                            } else
                            {

                                Model.EmplacementArticle emplacementArticle = new Model.EmplacementArticle();
                                emplacementArticle.DP_NoPrincipal = emplInsertion.DP_No;
                                emplacementArticle.DE_No = Depot.DE_No;
                                emplacementArticle.AR_Ref = article.ar_ref;
                                emplacementArticle.AG_No1 = 0;
                                emplacementArticle.AG_No2 = 0;
                                emplacementArticle.Add();
                            }
                            
                        }
                    }
                    
                }

                foreach(Model.F_GAMSTOCK articleGamme in ArticlesGamStock)
                {
                    if (articleGamme.DP_NoPrincipal != 0)
                    {
                        Console.WriteLine($"Traitement en cours de l'article en gamme : {articleGamme.ar_ref}");
                        Model.F_DEPOTEMPL emplacementSage = Model.F_DEPOTEMPL.ReadEmpl(Depot.DE_No, articleGamme.DP_NoPrincipal);

                        Model.Emplacements emplacementEasy = Model.Emplacements.ReadDepotEmplacement(Depot.DE_No, emplacementSage.DP_Code);

                        if (emplacementEasy != null)
                        {
                            Model.EmplacementArticle emplacementPrincipal = Model.EmplacementArticle.ReadEmplacementArticle(Depot.DE_No, articleGamme.ar_ref, articleGamme.AG_No1, articleGamme.AG_No2);
                            if (emplacementPrincipal != null)
                            {
                                emplacementPrincipal.DP_NoPrincipal = emplacementEasy.DP_No;
                                emplacementPrincipal.SaveDP_NoPrincipal();
                            }
                            else
                            {
                                emplacementPrincipal = new Model.EmplacementArticle();
                                emplacementPrincipal.DP_NoPrincipal = emplacementEasy.DP_No;
                                emplacementPrincipal.DE_No = Depot.DE_No;
                                emplacementPrincipal.AR_Ref = articleGamme.ar_ref;
                                emplacementPrincipal.AG_No1 = articleGamme.AG_No1;
                                emplacementPrincipal.AG_No2 = articleGamme.AG_No2;
                                emplacementPrincipal.Add();
                            }
                        }
                        else
                        {
                            Model.Emplacements empl = new Model.Emplacements();

                            empl.DE_No = Depot.DE_No;
                            empl.DP_Code = emplacementSage.DP_Code;
                            empl.DP_Intitule = emplacementSage.DP_Intitule;
                            empl.DP_Zone = null;
                            empl.DP_CapaciteMax = 0;
                            empl.DP_Hauteur = 0;
                            empl.DP_Largeur = 0;
                            empl.DP_Profondeur = 0;
                            empl.DP_Type = 0;
                            empl.DP_Position = 0;
                            empl.DP_PoidsMax = 0;
                            empl.Add();


                            Model.Emplacements emplInsertion = Model.Emplacements.ReadDepotEmplacement(Depot.DE_No, empl.DP_Code);

                            Model.EmplacementArticle emplacementPrincipal = Model.EmplacementArticle.ReadEmplacementArticle(Depot.DE_No, articleGamme.ar_ref, articleGamme.AG_No1, articleGamme.AG_No2);
                            if (emplacementPrincipal != null)
                            {
                                emplacementPrincipal.DP_NoPrincipal = emplInsertion.DP_No;
                                emplacementPrincipal.SaveDP_NoPrincipal();
                            }
                            else
                            {
                                Model.EmplacementArticle emplacementArticle = new Model.EmplacementArticle();
                                emplacementArticle.DP_NoPrincipal = emplInsertion.DP_No;
                                emplacementArticle.DE_No = Depot.DE_No;
                                emplacementArticle.AR_Ref = articleGamme.ar_ref;
                                emplacementArticle.AG_No1 = articleGamme.AG_No1;
                                emplacementArticle.AG_No2 = articleGamme.AG_No2;
                                emplacementArticle.Add();
                            }
                        }
                    }
                }

            }




        }
    }
}
