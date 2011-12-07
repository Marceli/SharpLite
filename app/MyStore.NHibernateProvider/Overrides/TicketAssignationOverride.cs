//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using MyStore.Domain;
//using MyStore.Domain.ProductMgmt;
//using NHibernate.Mapping.ByCode;

//namespace MyStore.NHibernateProvider.Overrides
//{
//    internal class TicketAssignationOverride:IOverride
//    {
//        public void Override(ModelMapper mapper) {
//            // Defines the ProductCategory side of the many-to-many relationship with Product
//            mapper.Class<Ticket>(map =>
//                map.Bag(x => x.Assignations,
//                    bag => {
//                        bag.Key(key => {
//                            key.Column("TiCategoryFk");
//                        });
//                        bag.Table("Products_ProductCategories");
//                        bag.Cascade(Cascade.None);
//                    },
//                    collectionRelation =>
//                        collectionRelation.ManyToMany(m => m.Column("ProductFk"))));

            
//            /*
//            // Initially the SubCategories and Parent were NOT mapped.
//            mapper.Class<ProductCategory>(map => map.Set(x => x.SubCategories,
//                                            set => {
//                                                set.Key(k => k.Column("ParentCategoryId"));
//                                                set.Inverse(true);
//                                            },
//                                                    ce => ce.OneToMany()));

//            mapper.Class<ProductCategory>(map => map.ManyToOne(x => x.Parent,
//                                            manyToOne => {
//                                                manyToOne.Column("ParentCategoryId");
//                                                manyToOne.Lazy(LazyRelation.NoLazy);
//                                                manyToOne.NotNullable(false);
//                                            }));
//            */
//        }
//    }
//}

//    }
//}
