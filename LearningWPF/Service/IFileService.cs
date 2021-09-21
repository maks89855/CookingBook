using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningWPF.Service
{
    public interface IFileService
    {
        List<Recipe> Open(string filename);
        void Save(string filename, List<Recipe> recipeList);
    }
}
