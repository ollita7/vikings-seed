import { Column, Entity, PrimaryGeneratedColumn } from 'typeorm';

@Entity()
export class role {
  @PrimaryGeneratedColumn()
  id: number;

  @Column({ length: 150 })
  name: string;

  @Column()
  createdAt: Date;

  @Column({ nullable: true })
  updatedAt: Date;
}
