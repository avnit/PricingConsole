namespace BlackSholvesModelPricing.Spanner
{
    internal class SpannerConnection
    {
        private object connectionString;

        public SpannerConnection(object connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}