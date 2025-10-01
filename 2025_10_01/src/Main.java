import java.io.*;
import java.util.*;

public class Main {
    public static void main(String[] args) throws IOException {
        List<Integer> numbers = new ArrayList<>();
        try (BufferedReader br = new BufferedReader(new FileReader("liczby.txt"))) {
            String line;
            while ((line = br.readLine()) != null) {
                numbers.add(Integer.parseInt(line.trim()));
            }
        }

        //  Zadanie 4.1
        int countSameDigits = 0;
        int firstSameDigitNumber = -1;
        for (int num : numbers) {
            String s = String.valueOf(num);
            if (s.charAt(0) == s.charAt(s.length() - 1)) {
                countSameDigits++;
                if (firstSameDigitNumber == -1) {
                    firstSameDigitNumber = num;
                }
            }
        }

        //  Zadanie 4.2
        int maxFactors = -1;
        int numberMaxFactors = -1;
        int maxDistinctFactors = -1;
        int numberMaxDistinctFactors = -1;

        for (int num : numbers) {
            List<Integer> factors = primeFactors(num);
            int total = factors.size();
            int distinct = new HashSet<>(factors).size();

            if (total > maxFactors) {
                maxFactors = total;
                numberMaxFactors = num;
            }
            if (distinct > maxDistinctFactors) {
                maxDistinctFactors = distinct;
                numberMaxDistinctFactors = num;
            }
        }

        // === Zadanie 4.3a === (dobre trójki)
        List<String> triples = new ArrayList<>();
        int tripleCount = 0;

        for (int i = 0; i < numbers.size(); i++) {
            for (int j = 0; j < numbers.size(); j++) {
                if (i == j) continue;
                if (numbers.get(j) % numbers.get(i) != 0) continue;
                for (int k = 0; k < numbers.size(); k++) {
                    if (i == k || j == k) continue;
                    if (numbers.get(k) % numbers.get(j) == 0) {
                        tripleCount++;
                        triples.add(numbers.get(i) + " " + numbers.get(j) + " " + numbers.get(k));
                    }
                }
            }
        }

        try (PrintWriter pw = new PrintWriter("trojki.txt")) {
            for (String t : triples) {
                pw.println(t);
            }
        }

        // Zadanie 4.3b
        int quintCount = 0;
        for (int a = 0; a < numbers.size(); a++) {
            for (int b = 0; b < numbers.size(); b++) {
                if (a == b) continue;
                if (numbers.get(b) % numbers.get(a) != 0) continue;
                for (int c = 0; c < numbers.size(); c++) {
                    if (c == a || c == b) continue;
                    if (numbers.get(c) % numbers.get(b) != 0) continue;
                    for (int d = 0; d < numbers.size(); d++) {
                        if (d == a || d == b || d == c) continue;
                        if (numbers.get(d) % numbers.get(c) != 0) continue;
                        for (int e = 0; e < numbers.size(); e++) {
                            if (e == a || e == b || e == c || e == d) continue;
                            if (numbers.get(e) % numbers.get(d) == 0) {
                                quintCount++;
                            }
                        }
                    }
                }
            }
        }

        //  Zapis wyników do wyniki4.txt
        try (PrintWriter pw = new PrintWriter("wyniki4.txt")) {
            pw.println("4.1 " + countSameDigits + " " + firstSameDigitNumber);
            pw.println("4.2 " + numberMaxFactors + " " + maxFactors + " " +
                    numberMaxDistinctFactors + " " + maxDistinctFactors);
            pw.println("4.3a " + tripleCount);
            pw.println("4.3b " + quintCount);
        }
    }

    // Rokład na czynniki
    private static List<Integer> primeFactors(int n) {
        List<Integer> factors = new ArrayList<>();
        int num = n;
        for (int i = 2; i * i <= num; i++) {
            while (n % i == 0) {
                factors.add(i);
                n /= i;
            }
        }
        if (n > 1) factors.add(n);
        return factors;
    }
}
