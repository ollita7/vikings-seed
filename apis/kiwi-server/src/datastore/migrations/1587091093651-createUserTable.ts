import {MigrationInterface, QueryRunner} from "typeorm";

export class createUserTable1587091093651 implements MigrationInterface {

  public async up(queryRunner: QueryRunner): Promise<any> {
    await queryRunner.query(
      `CREATE TABLE "user" 
        ("id" SERIAL NOT NULL, "password" character varying(150) NOT NULL, "email" character varying(50) NOT NULL,
        "username" character varying(50) NOT NULL, "createdAt" TIMESTAMP NOT NULL, "updatedAt" TIMESTAMP, 
        CONSTRAINT "PK_cace4a159ff9f2512dd42373760" PRIMARY KEY ("id"))`
    );
  }

  public async down(queryRunner: QueryRunner): Promise<any> {
    await queryRunner.query(`DROP TABLE "user"`);
  }


}
