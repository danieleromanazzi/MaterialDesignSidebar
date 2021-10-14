using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaterialDesignSidebarDemo.Data
{
    public class ReadData
    {
        private static readonly Lazy<ReadData> lazySerializer =
           new Lazy<ReadData>(() => new ReadData());

        public static ReadData Current
        {
            get { return lazySerializer.Value; }
        }

        public async Task<IEnumerable<Item>> GetSimpleData()
        {
            return await Task.Run(() =>
            {
                return new List<Item>()
                {
                    new Item("Big Tech","3 Elements", new List<Item>()
                    {
                        new Item("Microsoft","Redmond", PackIconKind.Microsoft),
                        new Item("Google","Mountain View", PackIconKind.Google),
                        new Item("Apple","Cupertino", PackIconKind.Apple),
                    }),
                    new Item("Mobile Operative System","2 Elements", new List<Item>()
                    {
                        new Item("Android","Redmond", PackIconKind.Android),
                        new Item("Ios","Mountain View", PackIconKind.AppleIos),
                    })
                };
            });
        }

        public async Task<IEnumerable<Item>> GetCompositeData()
        {
            return await Task.Run(() =>
            {
                return new List<Item>()
                {
                    new Item("Archive One","3 registrations", new List<Item>()
                    {
                        new Item("Registration 12 june 2021","2 documents", new List<Item>()
                        {
                            new Item("Document 1","subtitle document 1", PackIconKind.FileDocument),
                            new Item("Document 2","subtitle document 2", PackIconKind.FileDocument),
                        }),
                        new Item("Registration 16 agust 2021","2 documents", new List<Item>()
                        {
                            new Item("Document 3","subtitle document 3", PackIconKind.FileDocument),
                            new Item("Document 4","subtitle document 4", PackIconKind.FileDocument),
                        })
                    }),
                    new Item("Archive Two","3 registrations", new List<Item>()
                    {
                        new Item("Registration 5 june 2021","1 document", new List<Item>()
                        {
                            new Item("Document 5","subtitle document 5", PackIconKind.FileDocument),
                        }),
                        new Item("Registration 15 agust 2021","2 documents", new List<Item>()
                        {
                            new Item("Document 6","subtitle document 6", PackIconKind.FileDocument),
                            new Item("Document 7","subtitle document 7", PackIconKind.FileDocument),
                        })
                    })
                };
            });
        }
    }
}
