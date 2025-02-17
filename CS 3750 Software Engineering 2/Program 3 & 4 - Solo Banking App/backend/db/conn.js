const { MongoClient, ServerApiVersion } = require('mongodb');
const uri = process.env.ATLAS_URI;

let _db;
module.exports = {
    connectToServer: function(callback)
    {
        console.log("Attempting to connect");
                // Create a MongoClient with a MongoClientOptions object to set the Stable API version
        const client = new MongoClient(uri, {
            serverApi: {
            version: ServerApiVersion.v1,
            strict: true,
            deprecationErrors: true,
            }
    });
    
    async function run() {
        try {
        // Connect the client to the server	(optional starting in v4.7)
        await client.connect();
        // Send a ping to confirm a successful connection
        await client.db("admin").command({ ping: 1 });
        console.log("Pinged your deployment. You successfully connected to MongoDB!");
        // Checks if the bank cluster in the database is accessable
        await client.db("bank").command({ ping: 1 });
        // sets the cluster to be used to bank
        _db = client.db("bank");
        console.log("Successfully connected to accounts collection");
        } finally {
            
        }
    }
    run().catch(console.dir);
  },

  getDb: function() {
    return _db;
  }
};
