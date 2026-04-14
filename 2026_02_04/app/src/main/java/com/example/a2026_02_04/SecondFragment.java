package com.example.a2026_02_04;

import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

public class SecondFragment extends Fragment {
    public String email;
    public String name;
    public String surname;

    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        Bundle args = getArguments();
        if (args != null) {
            email = args.getString("email");
            name = args.getString("name");
            surname = args.getString("surname");
        } else if (savedInstanceState != null) {
            email = savedInstanceState.getString("email");
            name = savedInstanceState.getString("name");
            surname = savedInstanceState.getString("surname");
        }
    }

    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {

        View view = inflater.inflate(R.layout.fragment_second, container, false);
        TextView tv1 = view.findViewById(R.id.outtext1);
        TextView tv2 = view.findViewById(R.id.outtext2);
        TextView tv3 = view.findViewById(R.id.outtext3);

        tv1.setText("Email: "+ email);
        tv2.setText("Imię: "+name);
        tv3.setText("Nazwisko: "+surname);

        return view;
    }
}