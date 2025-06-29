
using FlagStorm.Data.Data;

public class RegionEntity: BaseEntity 
{
    public string Value { get; set; } = null!;

    public RegionDto ToDto()
    {
        return new RegionDto()
        {
            Id = Id,
            UpdatedAt = UpdatedAt,
            CreatedAt = CreatedAt,
            Value = Value,
        };
    }
}

public class BrowserEntity: BaseEntity  
{
    public string Value { get; set; } = null!;

    public BrowserDto ToDto()
    {
        return new BrowserDto()
        {
            Id = Id,
            CreatedAt = CreatedAt,
            UpdatedAt = UpdatedAt,
            Value = Value,
        };
    }
}

public class LocaleEntity: BaseEntity  
{
    public string Value { get; set; } = null!;

    public LocaleDto ToDto()
    {
        return new LocaleDto()
        {
            Id = Id,
            CreatedAt = CreatedAt,
            UpdatedAt = UpdatedAt,
            Value = Value,
        };
    }
}

public class AppVersionEntity: BaseEntity, IComparable<AppVersionEntity>
{
    public string Value { get; set; } = null!;

    public int Major => int.Parse(Value.Split('.')[0]);
    public int Minor => int.Parse(Value.Split('.')[1]);
    public int Patch => int.Parse(Value.Split('.')[2]);

   
    public int CompareTo(AppVersionEntity? other)
    {
        if (other == null) return 1;
        var result = Major.CompareTo(other.Major);
        if (result != 0) return result;
        result = Minor.CompareTo(other.Minor);
        if (result != 0) return result;
        return Patch.CompareTo(other.Patch);
    }
    public static bool operator <(AppVersionEntity left, AppVersionEntity right) => left.CompareTo(right) < 0;
    public static bool operator >(AppVersionEntity left, AppVersionEntity right) => left.CompareTo(right) > 0;
    public static bool operator <=(AppVersionEntity left, AppVersionEntity right) => left.CompareTo(right) <= 0;
    public static bool operator >=(AppVersionEntity left, AppVersionEntity right) => left.CompareTo(right) >= 0;

    public AppVersionDto ToDto()
    {
        return new AppVersionDto()
        {
            Id = Id,
            UpdatedAt = UpdatedAt,
            CreatedAt = CreatedAt,
            Value = Value,
        };
    }
}

public class OperatingSystemEntity: BaseEntity 
{
    public string Name { get; set; } = null!;

    public OperatingSystemDto ToDto()
    {
        return new OperatingSystemDto()
        {
            Id = Id,
            CreatedAt = CreatedAt,
            UpdatedAt = UpdatedAt,
            Name = Name,
        };
    }
}

public class EnvironmentNameEntity: BaseEntity  
{
    public string Value { get; set; } = null!;

    public EnvironmentNameDto ToDto()
    {
        return new EnvironmentNameDto()
        {
            Id = Id,
            CreatedAt = CreatedAt,
            UpdatedAt = UpdatedAt,
            Value = Value,
        };
    }
}

public class AccountIdEntity: BaseEntity  
{
    public string Value { get; set; } = null!;
     public AccountIdDto ToDto()
    {
        return new AccountIdDto()
        {
            Id = Id,
            CreatedAt = CreatedAt,
            UpdatedAt = UpdatedAt,
            Value = Value,
        };
    }
}

public class DeviceTypeEntity: BaseEntity 
{
    public string Value { get; set; } = null!;

    public DeviceTypeDto ToDto()
    {
        return new DeviceTypeDto()
        {
            Id = Id,
            UpdatedAt = UpdatedAt,
            CreatedAt = CreatedAt,
            Value = Value,
        };
    }
}

public class CustomerEntity: BaseEntity 
{
    public string Value { get; set; } = null!;
    
}