using MagicVilla_API.Modelos.Dto;

namespace MagicVilla_API.Datos
{
    public static class VillaStore
    {
        public static List<VillaDto> _lstVilla = new List<VillaDto> {
            new VillaDto { Id=1, Nombre = "Vista a la picinaStore", Ocupantes = 3, MetrosCuadrados = 200},
            new VillaDto { Id=2, Nombre = "Vista a la playaStore", Ocupantes = 5, MetrosCuadrados = 300},
            new VillaDto { Id=3, Nombre = "Vista al jardinStore", Ocupantes = 4, MetrosCuadrados = 400}
        };

    }
}
