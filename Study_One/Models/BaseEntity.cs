using System;

namespace Study_One.Models
{
    public abstract class BaseEntity
        //İKİ CLASSDA DA AYNI ŞEYİ DEĞİŞTİRMEDEN KULLANACAĞIMIZ İÇİN BUNLARI ABSTRACT SINIFIN İÇİNDE YAZABİLİRİZ

    {
      public DateTime CreatedOn { get; set; }
      public DateTime ModifiedOn { get; set; }
    }
}
