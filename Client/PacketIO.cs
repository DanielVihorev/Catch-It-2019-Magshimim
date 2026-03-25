using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Text.Json;

public class PacketWriter : BinaryWriter
{
    private MemoryStream _ms;
    private JsonSerializerOptions _jsonOptions;

    public PacketWriter()
        : base()
    {
        _ms = new MemoryStream();
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        OutStream = _ms;
    }

    public void Write(Image image)
    {
        using (var ms = new MemoryStream())
        {
            image.Save(ms, ImageFormat.Png);
            byte[] imageBytes = ms.ToArray();
            Write(imageBytes.Length);
            Write(imageBytes);
        }
    }

    // Generic-friendly writer; preferred when the compile-time type is known
    public void WriteObject<T>(T obj)
    {
        if (obj == null)
        {
            Write(-1);
            return;
        }

        byte[] bytes = JsonSerializer.SerializeToUtf8Bytes(obj, _jsonOptions);
        Write(bytes.Length);
        Write(bytes);
    }

    // Backward-compatible method that accepts object and serializes using its runtime type
    public void WriteT(object obj)
    {
        if (obj == null)
        {
            Write(-1);
            return;
        }

        byte[] bytes = JsonSerializer.SerializeToUtf8Bytes(obj, obj.GetType(), _jsonOptions);
        Write(bytes.Length);
        Write(bytes);
    }

    public byte[] GetBytes()
    {
        Close();
        byte[] data = _ms.ToArray();
        return data;
    }
}

public class PacketReader : BinaryReader
{
    private JsonSerializerOptions _jsonOptions;
    public PacketReader(byte[] data)
        : base(new MemoryStream(data))
    {
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public Image ReadImage()
    {
        int len = ReadInt32();
        if (len <= 0) return null;

        byte[] bytes = ReadBytes(len);

        Image img;
        using (MemoryStream ms = new MemoryStream(bytes))
        {
            img = Image.FromStream(ms);
        }

        return img;
    }

    public T ReadObject<T>()
    {
        int len = ReadInt32();
        if (len <= 0) return default;
        byte[] bytes = ReadBytes(len);
        return JsonSerializer.Deserialize<T>(bytes, _jsonOptions);
    }
}


