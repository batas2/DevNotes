using System;
using System.ComponentModel.DataAnnotations;

namespace UnitTests.ValueObjectValidation
{
    public enum Status
    {
        InProgress = 1,
        Done = 2
    }

    public class ValueObject
    {
        [Range(1, int.MaxValue)]
        public int KeyId { get; }

        [Range(1, int.MaxValue)]
        public int ForeignId { get; }

        [EnumDataType(typeof(Status))]
        public Status Status { get; }
        
        public DateTime StatusChangeDate { get; }
        
        public ValueObject(int keyId, int foreignId, Status status, DateTime statusChangeDate)
        {
            KeyId = keyId;
            ForeignId = foreignId;
            Status = status;
            StatusChangeDate = statusChangeDate;

            var message = $"Validation of {nameof(ValueObject)} failed for KeyId:{KeyId}, ForeignId:{ForeignId}, Status:{Status}";
            ValidationHelper.ValidateContract(this, message);
        }
    }
}