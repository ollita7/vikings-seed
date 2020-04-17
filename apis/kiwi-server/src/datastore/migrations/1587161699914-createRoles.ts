import {MigrationInterface, QueryRunner} from "typeorm";

export class createRoles1587161699914 implements MigrationInterface {

    public async up(queryRunner: QueryRunner): Promise<any> {
      `CREATE TABLE "role" 
        ("id" SERIAL NOT NULL, "name" character varying(150) NOT NULL, "createdAt" TIMESTAMP NOT NULL, "updatedAt" TIMESTAMP, 
        CONSTRAINT "PK_cace4a159ff9f2512dd4237376120" PRIMARY KEY ("id"));`;
    }

    public async down(queryRunner: QueryRunner): Promise<any> {
      //await queryRunner.query(`DROP TABLE "roles"`);
    }

}
