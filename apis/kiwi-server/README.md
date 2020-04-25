# Kiwi-server Flavor
Built using only nodejs core. Lightweight, intuitive with great performance and response timing.

If you want to read more about it please go to [kiwi-server.com](kiwi-server.com)

## Getting started
* Install the dependencies 
```bash
npm install
```

* Install kiwi-server CLI
```bash 
npm install kiwi-server-cli -g
```


* Run the migrations to create the database schema:
```bash
node run migration run
```

* Revert the migrations to create the database schema:
```bash
node run migration revert
```

* Create new migration
```bash
npx typeorm migration:create -n <migrationname>
```

