using System;
using System.Collections.Generic;

namespace CreameryOps
{
    public class BatchRecord
    {
        public string BatchId { get; set; } = string.Empty;
        public double LitersProcessed { get; set; }
    }

    public class CreameryBatchHistory
    {
        private readonly List<BatchRecord> _records = new List<BatchRecord>();

        public void Record(BatchRecord record)
        {
            _records.Add(record);
        }

        public int Count()
        {
            return _records.Count;
        }

        public double TotalLiters()
        {
            double total = 0;
            foreach (var record in _records)
            {
                total += record.LitersProcessed;
            }
            return total;
        }

        public BatchRecord? FindByBatchId(string batchId)
        {
            foreach (var record in _records)
            {
                if (record.BatchId == batchId)
                {
                    return record;
                }
            }
            return null;
        }

        public BatchRecord? Latest()
        {
            if (_records.Count == 0)
            {
                return null;
            }
            return _records[_records.Count - 1];
        }

        public List<BatchRecord> AboveLiters(double liters)
        {
            var result = new List<BatchRecord>();
            foreach (var record in _records)
            {
                if (record.LitersProcessed > liters)
                {
                    result.Add(record);
                }
            }
            return result;
        }
    }
}
