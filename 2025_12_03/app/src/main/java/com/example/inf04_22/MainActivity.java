package com.example.inf04_22;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;


public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_main);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });
        Button button = (Button) findViewById(R.id.button);
        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                EditText emailEntry = (EditText) findViewById(R.id.editTextText);
                String email = emailEntry.getText().toString();
                TextView output = (TextView) findViewById(R.id.outputTextView);
                output.setText("Autor: 00000000000");
                if(!email.contains("@"))
                {
                    output.setText("Autor: 00000000000\n"+MainActivity.this.getString(R.string.to_nie_jest_email));
                }
                else
                {
                    EditText passwordEntry1 = (EditText) findViewById(R.id.editTextTextPassword);
                    EditText passwordEntry2 = (EditText) findViewById(R.id.editTextTextPassword2);

                    if(!passwordEntry1.getText().toString().equals(passwordEntry2.getText().toString()))
                    {
                        output.setText("Autor: 00000000000\n"+MainActivity.this.getString(R.string.hasla_sie_nie_zgadzaja));
                    }
                    else
                    {
                        output.setText("Autor: 00000000000\nWitaj " + email);
                    }
                }
            }
        });
    }
}