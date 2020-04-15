module.exports = {
  type: 'postgres',
  url: process.env.DATABASE_URL,
  synchronize: false,
  logging: false,
  entities: ['dist/default/src/datastore/entities/**/*.js'],
  migrations: ['dist/default/src/datastore/migrations/**/*.js'],
  subscribers: ['dist/default/src/datastore/subscriber/**/*.ts'],
  cli: {
    entitiesDir: 'src/datastore/entities',
    migrationsDir: 'src/datastore/migrations',
    subscribersDir: 'src/datastore/subscribers'
  }
};
