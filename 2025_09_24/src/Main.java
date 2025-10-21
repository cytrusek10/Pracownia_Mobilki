import java.io.*;
import java.util.*;

public class Main {
    public static void main(String[] args) throws IOException {
        List<Integer> nums = new ArrayList<>();
        Scanner sc = new Scanner(new File("liczby.txt"));
        while (sc.hasNextInt()) nums.add(sc.nextInt());
        sc.close();

        int countSame = 0;
        int firstSame = 0;
        boolean found = false;

        for (int n : nums) {
            String s = String.valueOf(n);
            if (s.charAt(0) == s.charAt(s.length() - 1)) {
                countSame++;
                if (!found) {
                    firstSame = n;
                    found = true;
                }
            }
        }

        int maxFactors = 0;
        int numMaxFactors = 0;
        int maxUnique = 0;
        int numMaxUnique = 0;

        for (int n : nums) {
            List<Integer> factors = getFactors(n);
            Set<Integer> unique = new HashSet<>(factors);
            if (factors.size() > maxFactors) {
                maxFactors = factors.size();
                numMaxFactors = n;
            }
            if (unique.size() > maxUnique) {
                maxUnique = unique.size();
                numMaxUnique = n;
            }
        }

        List<String> triplets = new ArrayList<>();
        for (int x : nums)
            for (int y : nums)
                for (int z : nums)
                    if (x != y && y != z && x != z && y % x == 0 && z % y == 0)
                        triplets.add(x + " " + y + " " + z);

        PrintWriter tripFile = new PrintWriter("triplets.txt");
        for (String t : triplets) tripFile.println(t);
        tripFile.close();

        int quintuples = 0;
        for (int a : nums)
            for (int b : nums)
                for (int c : nums)
                    for (int d : nums)
                        for (int e : nums)
                            if (a!=b && b!=c && c!=d && d!=e && a!=c && a!=d && a!=e && b!=d && b!=e && c!=e)
                                if (b%a==0 && c%b==0 && d%c==0 && e%d==0)
                                    quintuples++;

        PrintWriter out = new PrintWriter("results4.txt");
        out.println("4.1 " + countSame + " " + firstSame);
        out.println("4.2 " + numMaxFactors + " " + maxFactors + " " + numMaxUnique + " " + maxUnique);
        out.println("4.3a " + triplets.size());
        out.println("4.3b " + quintuples);
        out.close();

        System.out.println("Done! Check results4.txt and triplets.txt");
    }

    static List<Integer> getFactors(int n) {
        List<Integer> list = new ArrayList<>();
        int d = 2;
        while (n > 1) {
            while (n % d == 0) { list.add(d); n /= d; }
            d++;
        }
        return list;
    }
}
