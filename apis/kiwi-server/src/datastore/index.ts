 
import 'reflect-metadata';
import {createConnection, Connection} from "typeorm";

const connection: Promise<void | Connection> = createConnection({
  type: "postgres",
  url: process.env.DATABASE_URL,
  synchronize: false,
  logging: false
}).catch((error: any) => console.log(error));


export async function getRepository<T>(arg: {new(): T; }): Promise<any> {
  const conn = await connection;
  if (!conn) throw new Error('Connection to db not available');

  return conn.getRepository(arg);
}

