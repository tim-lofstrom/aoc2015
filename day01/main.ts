import { first, reduce, split, tail } from "lodash";
import { readInputLine } from "../utils/file-utils";

const input = readInputLine(__dirname, "input.txt");
const parts = split(input, "");

function calcNextFloor(floor: number, direction: string | undefined) {
  switch (direction) {
    case "(":
      return floor + 1;
    case ")":
      return floor - 1;
    default:
      return floor;
  }
}

function basement(parts: string[] | undefined, floor: number): number {
  if (floor === -1) return 0;
  const direction = first(parts);
  const rest = tail(parts);
  const nextFloor = calcNextFloor(floor, direction);
  return 1 + basement(rest, nextFloor);
}

const part1 = reduce(parts, (floor, direction) => calcNextFloor(floor, direction), 0);
const part2 = basement(parts, 0);

console.log(part1);
console.log(part2);
