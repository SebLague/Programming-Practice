using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ImageSlicer {

    public static Texture2D[,] GetSlices(Texture2D image, int blocksPerLine)
    {
        int imageSize = Mathf.Min(image.width, image.height);
        int blockSize = imageSize / blocksPerLine;

        Texture2D[,] blocks = new Texture2D[blocksPerLine, blocksPerLine];

        for (int y = 0; y < blocksPerLine; y++)
        {
            for (int x = 0; x < blocksPerLine; x++)
            {
                Texture2D block = new Texture2D(blockSize, blockSize);
                block.wrapMode = TextureWrapMode.Clamp;
                block.SetPixels(image.GetPixels(x * blockSize, y * blockSize, blockSize, blockSize));
                block.Apply();
                blocks[x, y] = block;
            }
        }

        return blocks;
    }
}
