using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using TwitterUCU;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
        PictureProvider provider = new PictureProvider();
        IPicture picture = provider.GetPicture(@"beer.jpg");

        IPipe nulo = new PipeNull();
        IFilter negative = new FilterNegative();
        IPipe serialPipe1 = new PipeSerial(negative,nulo);
        IFilter greyscale = new FilterGreyscale();
        IPipe serialPipe2 = new PipeSerial(greyscale, serialPipe1);// termina de aplicar los filtros 
         
        IPicture picture1 = serialPipe2.Send(picture);// guarda los cambios de los filtros 
        
        provider.SavePicture(picture1 , @"cerveija.jpg");

        TwitterImage twitter = new TwitterImage();
        Console.WriteLine(twitter.PublishToTwitter("MESSIENTO TRISTE", @"cerveija.jpg" ));

        }
    }
}
