using Acme.BookStore.Domain.Shared;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Domain.Books
{
    /// <summary>
    /// Book实体继承了AuditedAggregateRoot,AuditedAggregateRoot类在AggregateRoot类的基础上添加了一些基础审计属性(例如CreationTime, CreatorId, LastModificationTime 等). ABP框架自动为你管理这些属性.
    /// Guid是Book实体的主键类型.
    /// </summary>
    public class Book : AuditedAggregateRoot<Guid>, ISoftDelete
    {
        public string? Name { get; set; }

        public BookType Type { get; set; }

        public DateTime PublishDate { get; set; }

        public float Price { get; set; }

        public bool IsDeleted { get; set; }
    }
}
