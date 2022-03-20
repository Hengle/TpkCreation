﻿using AssetRipper.TpkCreation.Compression;
using NUnit.Framework;

namespace AssetRipper.TpkCreation.Tests
{
	public class CompressionTests
	{
		private readonly byte[] randomData = RandomUtils.RandomBytes(4096);

		[Test]
		public void BrotliCompressionReversesPerfectly()
		{
			byte[] compressedData = BrotliHandler.Compress(randomData);
			if (compressedData.Length == 0)
				Assert.Fail("Compressed data cannot be empty");
			byte[] decompressedData = BrotliHandler.Decompress(compressedData);
			Assert.AreEqual(randomData, decompressedData);
		}

		[Test]
		public void Lz4CompressionReversesPerfectly()
		{
			byte[] compressedData = Lz4Handler.Compress(randomData);
			if (compressedData.Length == 0)
				Assert.Fail("Compressed data cannot be empty");
			byte[] decompressedData = Lz4Handler.Decompress(compressedData, randomData.Length);
			Assert.AreEqual(randomData, decompressedData);
		}

		[Test]
		public void LzmaCompressionReversesPerfectly()
		{
			byte[] compressedData = LzmaHandler.Compress(randomData);
			if (compressedData.Length == 0)
				Assert.Fail("Compressed data cannot be empty");
			byte[] decompressedData = LzmaHandler.Decompress(compressedData, randomData.Length);
			Assert.AreEqual(randomData, decompressedData);
		}
	}
}
