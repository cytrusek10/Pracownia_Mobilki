package com.example.zadanie104

import android.Manifest
import android.app.NotificationChannel
import android.app.NotificationManager
import android.app.PendingIntent
import android.content.Context
import android.content.Intent
import android.content.pm.PackageManager
import android.os.Build
import android.os.Bundle
import android.widget.Button
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import androidx.core.app.ActivityCompat
import androidx.core.app.NotificationCompat
import androidx.core.app.NotificationManagerCompat
import androidx.core.content.ContextCompat

class MainActivity : AppCompatActivity() {

    companion object {
        const val CHANNEL_HIGH_ID = "channel_high"
        const val CHANNEL_LOW_ID  = "channel_low"
        const val NOTIF_HIGH_ID   = 1001
        const val NOTIF_LOW_ID    = 1002
        const val REQ_PERMISSION  = 100
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        createNotificationChannels()
        requestNotificationPermission()

        findViewById<Button>(R.id.btn1).setOnClickListener {
            sendHighPriorityNotification()
        }

        findViewById<Button>(R.id.btn2).setOnClickListener {
            sendLowPriorityNotification()
        }
    }

    private fun createNotificationChannels() {
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
            val nm = getSystemService(Context.NOTIFICATION_SERVICE) as NotificationManager

            // HIGH priority channel
            val highChannel = NotificationChannel(
                CHANNEL_HIGH_ID,
                getString(R.string.channel_high),
                NotificationManager.IMPORTANCE_HIGH
            ).apply {
                description = "Powiadomienia wysokiego priorytetu"
                enableVibration(true)
            }

            // LOW priority channel
            val lowChannel = NotificationChannel(
                CHANNEL_LOW_ID,
                getString(R.string.channel_low),
                NotificationManager.IMPORTANCE_MIN
            ).apply {
                description = "Powiadomienia niskiego priorytetu"
                enableVibration(false)
            }

            nm.createNotificationChannel(highChannel)
            nm.createNotificationChannel(lowChannel)
        }
    }

    private fun requestNotificationPermission() {
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.TIRAMISU) {
            if (ContextCompat.checkSelfPermission(
                    this, Manifest.permission.POST_NOTIFICATIONS
                ) != PackageManager.PERMISSION_GRANTED
            ) {
                ActivityCompat.requestPermissions(
                    this,
                    arrayOf(Manifest.permission.POST_NOTIFICATIONS),
                    REQ_PERMISSION
                )
            }
        }
    }

    private fun sendHighPriorityNotification() {
        // PendingIntent -> Activity2
        val intent = Intent(this, Activity2::class.java).apply {
            flags = Intent.FLAG_ACTIVITY_NEW_TASK or Intent.FLAG_ACTIVITY_CLEAR_TASK
        }
        val pendingIntent = PendingIntent.getActivity(
            this, 0, intent,
            PendingIntent.FLAG_UPDATE_CURRENT or PendingIntent.FLAG_IMMUTABLE
        )

        val notification = NotificationCompat.Builder(this, CHANNEL_HIGH_ID)
            .setSmallIcon(R.drawable.ic_notification)
            .setContentTitle(getString(R.string.notif_high_title))
            .setContentText(getString(R.string.notif_high_text))
            .setPriority(NotificationCompat.PRIORITY_MAX)
            .setCategory(NotificationCompat.CATEGORY_ALARM)
            .setContentIntent(pendingIntent)
            .setAutoCancel(true)
            .build()

        if (hasNotifPermission()) {
            NotificationManagerCompat.from(this).notify(NOTIF_HIGH_ID, notification)
        } else {
            Toast.makeText(this, "Brak uprawnień do powiadomień", Toast.LENGTH_SHORT).show()
        }
    }

    private fun sendLowPriorityNotification() {
        // PendingIntent -> Activity3
        val intent = Intent(this, Activity3::class.java).apply {
            flags = Intent.FLAG_ACTIVITY_NEW_TASK or Intent.FLAG_ACTIVITY_CLEAR_TASK
        }
        val pendingIntent = PendingIntent.getActivity(
            this, 1, intent,
            PendingIntent.FLAG_UPDATE_CURRENT or PendingIntent.FLAG_IMMUTABLE
        )

        val notification = NotificationCompat.Builder(this, CHANNEL_LOW_ID)
            .setSmallIcon(R.drawable.ic_notification)
            .setContentTitle(getString(R.string.notif_low_title))
            .setContentText(getString(R.string.notif_low_text))
            .setPriority(NotificationCompat.PRIORITY_MIN)
            .setContentIntent(pendingIntent)
            .setAutoCancel(true)
            .build()

        if (hasNotifPermission()) {
            NotificationManagerCompat.from(this).notify(NOTIF_LOW_ID, notification)
        } else {
            Toast.makeText(this, "Brak uprawnień do powiadomień", Toast.LENGTH_SHORT).show()
        }
    }

    private fun hasNotifPermission(): Boolean {
        return if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.TIRAMISU) {
            ContextCompat.checkSelfPermission(
                this, Manifest.permission.POST_NOTIFICATIONS
            ) == PackageManager.PERMISSION_GRANTED
        } else true
    }
}
