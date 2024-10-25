import { first, last, map, reduce, rest, split, tail } from "lodash";
import { readInputLine } from "../utils/file-utils";

const input = readInputLine(__dirname, "input.txt");
const parts = split(input, "");

function calcNext(acc: number, curr: string | undefined) {
  if (curr === "(") {
    return acc + 1;
  } else if (curr === ")") {
    return acc - 1;
  }
  return acc;
}

function basement(parts: string[] | undefined, floor: number): number {
  if (floor === -1) return 0;
  const f = first(parts);
  const t = tail(parts);
  return basement(t, calcNext(floor, f)) + 1;
}

const part1 = reduce(parts, (acc, curr) => calcNext(acc, curr), 0);
const part2 = basement(parts, 0);

console.log(part1);
console.log(part2);
