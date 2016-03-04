namespace MISL.Ababil.Agent.Infrastructure.Validation
{
    public enum ValidationType
    {
        // Text
        NonEmptyText = 1,
        NonWhitespaceNonEmptyText = 2,
        NonEmptyTextWithoutWhitespaceCharactersInside = 8,
        NonEmptyTextWithoutSpecialCharactersInside = 16,
        AtLeastOneSpecialCharacterInside = 32,
        AtLeastOneDigitInside = 64,
        ContainsParticularText = 128,
        StartsWithParticularText = 256,
        EndsWithParticularText = 512,
        TextWithLengthRange = 1024,
        
        // Numeric
        Numeric = 2048,
        Integral = 4096,
        WithinRange = 8192,
        Positive = 16384,
        NonZero = 32768,

        // Particular

        BangladeshiCellphoneNumber = 65536,
        EmailAddress = 131072,
        ListSelected = 262144,
        UserName = 524288,
        Password = 1048576,
        BangladeshiLandPhoneNumber = 2097152,
        GridHasRows = 4194304,

        // Logical
        
        OnlyCheckIfNotEmpty = 8388608,
        StrongPassword = 16777216

    }
}