using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG2A_GUI_POE
{
    
        public class IngredientDetails //this class will store all information for each of the ingredietns
        {
            //------------------------Ingredient Properties--------------------------------
            public string Name { get; set; }
            public float Quantity { get; set; }
            public float Scaled { get; set; }
            public string Measurement { get; set; }
            public float Calories { get; set; }
            public string foodGroup { get; set; }
            //------------------------ End of Ingredient Properties -------------------------
            //------------------------ Ingredient Constructor -------------------------------
            public void CreateIngredient(string nam, float quant, string meas, float cal, string group)
            {
                Name = nam;
                Quantity = quant;
                Scaled = 1;
                Measurement = meas;
                Calories = cal;
                foodGroup = group;
            }
            //------------------------ end of ingredient constructor ----------------------------
            //------------------------ Ingredient Methods ---------------------------------------
            // displayIngredient Mehtod
            //Will display a neat ext representation of the ingredeitn
            public string displayIngredient()
            {
                string otpt = (Quantity.ToString() + " " + Measurement + " of " + Name + ". This is " + Calories.ToString() + " calories in the " + foodGroup + " food group.");
                return otpt;
            }
            // End of display Mehtod
            // scale Method
            //Will scale the ingredeint to the given value
            public void scale(float scale)
            {
                Quantity *= scale;
                Calories *= scale;
                Scaled *= scale;
            }
            // End of scale Method
            // resetScale Method
            //Will reset the ingredeint qunatities and calories to their original value before any scaling
            public void resetScale()
            {
                Quantity = Quantity/Scaled;
                Calories = Calories/Scaled;
                Scaled = 1;
            }
            // End of resetScale Method
        }
        public class Recipe
        {
            //------------------------Recipe Properties-------------------------------------
            public string recipeName { get; set; }
            public Dictionary<string, IngredientDetails> recipeIngredients { get; set; }
            public List<string> recipeSteps { get; set; }
            //------------------------ End of Recipe Properties-------------------------------------
            public void CreateRecipe(string name, Dictionary<string, IngredientDetails> ings, List<string> stps)
            {
                //------------------------ Recipe Constructos -----------------------------------------
                recipeName = name;
                recipeIngredients = ings;
                recipeSteps = stps;
            }
            //---------------------------- End of Recipe Constructors -------------------------
            //---------------------------- Recipe Mehthods -------------------------------------
            //DisplayRecipe Method
            //Will print the full recipe in a pleasent format
            public string DisplayRecipe()
            {
                string otpt = ""; //this will be the output string containing the full text ingredient description

                int count = 0;
                otpt = (recipeName+":\n");
                otpt = (otpt + "Ingredient List:\n");
                foreach (var pair in recipeIngredients)
                {
                    count++;
                    otpt = (otpt + count.ToString() + ". " + pair.Value.displayIngredient()+"\n");
                }
                otpt = (otpt + "Steps:\n");
                count = 0;
                foreach (var stp in recipeSteps)
                {
                    count++;
                    otpt = (otpt + count.ToString() + ". " + stp + "\n");
                }
                otpt = (otpt + "Calories:\n");
                float tot = 0;
                foreach (var pair in recipeIngredients)
                {
                    tot += pair.Value.Calories;
                }
                otpt = (otpt + tot.ToString());
                return otpt;
            }
            // End of DisplayRecipe Method
            //ScaleQuant method
            //sclaes the quantity of the ingredients by the desired factor
            public void ScaleQuant(float scal)
            {
                foreach (var pair in recipeIngredients)
                {
                    pair.Value.scale(scal);
                }
            }
            //end of the ScaleQuant method
            //ResetQuant method
            //Sets the QUantity values to the inital ones input (relevant after the use of the scale QUant method)
            public void ResetQuant()
            {
                foreach (var pair in recipeIngredients)
                {
                    pair.Value.resetScale();
                }
            }
            //End of ResetQuant method
            //Totalcal Method
            //Calculate total calories method
            public float Totalcal()
            {
                float tot = 0;
                foreach (var pair in recipeIngredients)
                {
                    tot += pair.Value.Calories;
                }
                return tot;
            }
            //End of Totalcal method
            //foodGrouppercent Method
            //will output the percentage breakdown of the foodgroups in the recipe
            public List<int> FoodGroupPerc()
        {
            List<int> outlist = new List<int>();
            float tot = 0;
            float starchtot = 0;
            float vegtot = 0;
            float beantot = 0;
            float meattot = 0;
            float fattot = 0;
            float dairytot = 0;
            float watertot = 0;
            foreach (var pair in recipeIngredients)
            {
                tot += pair.Value.Calories;
                if (pair.Value.foodGroup == "starch")
                {
                    starchtot += pair.Value.Calories;
                }
                if (pair.Value.foodGroup == "fruit and veg")
                {
                    vegtot+= pair.Value.Calories;
                }
                if (pair.Value.foodGroup == "beans")
                {
                    beantot += pair.Value.Calories;
                }
                if (pair.Value.foodGroup == "meat")
                {
                    meattot += pair.Value.Calories;
                }
                if (pair.Value.foodGroup == "fat")
                {
                    fattot += pair.Value.Calories;
                }
                if (pair.Value.foodGroup == "dairy")
                {
                    dairytot += pair.Value.Calories;
                }
                if (pair.Value.foodGroup == "water")
                {
                    watertot += pair.Value.Calories;
                }
            }
            outlist.Add((int)Math.Round(100*starchtot/tot));
            outlist.Add((int)Math.Round(100*vegtot/tot));
            outlist.Add((int)Math.Round(100 * beantot/tot));
            outlist.Add((int)Math.Round(100 * meattot / tot));
            outlist.Add((int)Math.Round(100 * fattot /tot));
            outlist.Add((int)Math.Round(100 * dairytot / tot));
            outlist.Add((int)Math.Round((100 * watertot / tot)));
            return outlist;
        }
        //End of foodgrouppercent Method
        //contrainsFG
        //returns a boolean value weather the recipe contains a specific food group
        public bool containsFG(string fg)
        {
            bool ans = false;
            List<string> foodgroups = new List<string>();
            foreach (var item in recipeIngredients)
            {
                if (item.Value.foodGroup == fg)
                {
                    ans = true;
                }
            }
            return ans;
        }

            //---------------------------- End of Recipe Methods ------------------------------
        }
    }
