﻿namespace InTime.Keys.Domain.Common;

public abstract class BaseEntity : IEntity
{
    private readonly List<BaseEvent> _domainEvents = new();

    public Guid Id { get; protected set; }
    protected BaseEntity(Guid id)
    {
        Id = id;
    }
    protected BaseEntity(){}
    public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(BaseEvent domainEvent) => _domainEvents.Add(domainEvent);
    public void RemoveDomainEvent(BaseEvent domainEvent) => _domainEvents.Remove(domainEvent);
    public void ClearDomainEvemt() => _domainEvents.Clear();
}