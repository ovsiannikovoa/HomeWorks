// Abstractions/IPlacementService.cs
using CSharpFunctionalExtensions;
using FamalyPlacment.Models;

namespace FamalyPlacment.Abstractions
{
    public interface IPlacementService
    {
        // Разместить дерево указанного типа в количестве count
        Result Place(TreeType selectedTreeType, int count);
    }
}