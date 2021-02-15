using AutoFixture;
using System;

namespace UnitTests.ValueObjectValidation
{
    public class ValueObjectBuilder
    {
        private int? _keyId;
        private int? _foreignId;
        private Status? _status;

        public static ValueObjectBuilder AValueObject()
            => new ValueObjectBuilder();

        public ValueObjectBuilder WithStatus(Status status)
            => this.Do(b => b._status = status);

        public ValueObjectBuilder WithKeyId(int supplierTempId)
            => this.Do(b => b._keyId = supplierTempId);

        public ValueObjectBuilder WithForeignId(int clientId)
            => this.Do(b => b._foreignId = clientId);

        public ValueObject Build()
        {
            var fixture = new Fixture();
            return new ValueObject(
                keyId: _keyId ?? fixture.Create<int>(),
                foreignId: _foreignId?? fixture.Create<int>(),
                status: _status ?? fixture.Create<Status>(),
                statusChangeDate: fixture.Create<DateTime>());
        }
    }
}