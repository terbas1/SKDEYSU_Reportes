using Logín.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Logín.ViewModels
{
    public class MylistPageViewModel
    {
        public ObservableCollection<MylistDocuments> DocumentList { get; set; }
        public MylistPageViewModel()
        {
            DocumentList = new ObservableCollection<MylistDocuments>();
            DocumentList.Add(new MylistDocuments { Name = "Inspección HSEC", Image = "https://images.vexels.com/media/users/3/135981/isolated/preview/a76da04c88caa20980568f49107d908e-icono-de-carpeta-de-documentos-by-vexels.png", Detail = "Observación Preventiva", Ingredients = "-------" });
            DocumentList.Add(new MylistDocuments { Name = "Inspección HSEC", Image = "https://img2.freepng.es/20180423/thq/kisspng-computer-icons-document-management-system-clip-art-documents-5addc62dc7a2e5.9565990315244836298177.jpg", Detail = "Documento de Inspección", Ingredients = "------" });
            DocumentList.Add(new MylistDocuments { Name = "Inspección HSEC", Image = "https://img2.freepng.es/20190530/vbh/kisspng-document-file-format-computer-file-portable-networ-man-clipart-question-mark-pass-board-exam-72-5cef71e2620cd4.1757690015591961304016.jpg", Detail = "Observación Planeada de Tareas (OPT)", Ingredients = "------" });
        }
    }
}
