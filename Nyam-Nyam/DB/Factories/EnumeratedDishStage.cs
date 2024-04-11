using Nyam_Nyam.DB;

namespace Nyam_Nyam.DB.Factories
{
    public class EnumeratedDishStage
    {
        public EnumeratedDishStage(CookingStage dishStage,
                                        string numberOfStage)
        {
            DishStage = dishStage;
            NumberOfStage = numberOfStage;
        }

        public CookingStage DishStage { get; }
        public string NumberOfStage { get; set; }
    }
}
