using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SearachAppSample.Core
{
    /// <summary>
    /// プロジェクトを表すクラス
    /// </summary>
    public class Project
    {
        private readonly string _projectFilePath;
        private ProjectContext _context;

        public string Path { get; }
        public string Name { get; private set; }
        public DateTime LastModified { get; private set; }
        public ProjectContext Context => _context;

        public event EventHandler<ProjectContext> ContextChanged;

        public Project(string path)
        {
            Path = path;
            Name = System.IO.Path.GetFileNameWithoutExtension(path);
            _projectFilePath = System.IO.Path.Combine(path, "project.json");
        }

        public void Load()
        {
            if (File.Exists(_projectFilePath))
            {
                string json = File.ReadAllText(_projectFilePath);
                _context = JsonSerializer.Deserialize<ProjectContext>(json) ?? new ProjectContext();
            }
            else
            {
                _context = new ProjectContext();
            }

            LastModified = File.Exists(_projectFilePath)
                ? File.GetLastWriteTime(_projectFilePath)
                : DateTime.Now;
        }

        public void Save()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(_context, options);
            File.WriteAllText(_projectFilePath, json);

            LastModified = DateTime.Now;
        }

        public void UpdateContext(Action<ProjectContext> updateAction)
        {
            updateAction(_context);
            ContextChanged?.Invoke(this, _context);
        }
    }
}
