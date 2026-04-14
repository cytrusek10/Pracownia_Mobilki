package com.example.inf04_22;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class MainActivity extends AppCompatActivity
{
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_main);

        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

        Button button = (Button) findViewById(R.id.button);
        button.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v)
            {
                EditText emailEntry = (EditText) findViewById(R.id.editTextText);
                String email = emailEntry.getText().toString();
                TextView output = (TextView) findViewById(R.id.outputTextView);
                output.setText("Autor: 00000000000");

                EditText passwordEntry1 = (EditText) findViewById(R.id.editTextTextPassword);
                EditText passwordEntry2 = (EditText) findViewById(R.id.editTextTextPassword2);

                String password = passwordEntry1.getText().toString();
                output.setTextColor(0xFF0000FF);

                // Email
                if(!Pattern.matches("^[a-zA-Z0-9.-_]+@[a-zA-Z0-9.-_]+$", email)){
                    output.setText("Witaj "+email+"\n"+MainActivity.this.getString(R.string.to_nie_jest_email));
                }
                else if (!password.equals(passwordEntry2.getText().toString()))
                {
                    output.setText("Witaj "+email+"\n"+MainActivity.this.getString(R.string.hasla_sie_nie_zgadzaja));
                }
                else if(password.length() < 8)
                {
                    output.setText("Witaj "+email+"\n"+"Hasło powinno zawierać co najmniej 8 znaków");
                }
                else if (!password.matches(".*\\d+.*"))
                {
                    output.setText("Witaj "+email+"\n"+"Hasło powinno zawierać co najmniej 1 cyfrę");
                }
                else if (!password.matches(".*[A-Z]+.*"))
                {
                    output.setText("Witaj "+email+"\n"+"Hasło powinno zawierać co najmniej 1 dużą literę");
                }
                else if (!password.matches(".*[a-z]+.*"))
                {
                    output.setText("Witaj "+email+"\n"+"Hasło powinno zawierać co najmniej 1 małą literę");
                }
                else
                {
                    output.setTextColor(0xFF000000);
                    output.setText("Autor: 00000000000\nWitaj " + email);

                    Intent i = new Intent(MainActivity.this, MainActivity2.class);
                    i.putExtra("email", email);
                    startActivity(i);
                }
            }
        });
    }
}